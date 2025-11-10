using AP.BTP.Application.CQRS.Auth0User;
using AP.BTP.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Net;
using System.Text.Json;

namespace AP.BTP.Infrastructure.Auth0
{
    /// <summary>
    /// Service for managing users and roles in Auth0 using the Management API.
    /// </summary>
    public class Auth0ManagementService : IAuth0ManagementService
    {
        private readonly string _domain;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _audience;
        private string? _cachedToken;
        private DateTime _tokenExpiry;

        /// <summary>
        /// Initializes a new instance of the <see cref="Auth0ManagementService"/> class with configuration values.
        /// </summary>
        /// <param name="config">The configuration containing Auth0 credentials.</param>
        /// <exception cref="ArgumentNullException">Thrown if any required Auth0 configuration is missing.</exception>
        public Auth0ManagementService(IConfiguration config)
        {
            _domain = config["AUTH0:DOMAIN"] ?? throw new ArgumentNullException("AUTH0:DOMAIN");
            _clientId = config["AUTH0:MANAGEMENT_CLIENT_ID"] ?? throw new ArgumentNullException("AUTH0:MANAGEMENT_CLIENT_ID");
            _clientSecret = config["AUTH0:MANAGEMENT_CLIENT_SECRET"] ?? throw new ArgumentNullException("AUTH0:MANAGEMENT_CLIENT_SECRET");
            _audience = $"https://{_domain}/api/v2/";
        }

        /// <summary>
        /// Retrieves a cached management API token or requests a new one if expired.
        /// </summary>
        /// <returns>A <see cref="Task{String}"/> representing the access token.</returns>
        private async Task<string> GetManagementTokenAsync()
        {
            if (_cachedToken != null && DateTime.UtcNow < _tokenExpiry) return _cachedToken;

            RestClient client = new RestClient($"https://{_domain}/oauth/token");
            RestRequest request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("content-type", "application/json");

            request.AddJsonBody(new
            {
                client_id = _clientId,
                client_secret = _clientSecret,
                audience = _audience,
                grant_type = "client_credentials"
            });

            RestResponse response = await client.ExecuteAsync(request);

            if (!response.IsSuccessful)
            {
                throw new InvalidOperationException($"Failed to get Auth0 management token: {response.StatusCode}");
            }

            JsonDocument json = JsonDocument.Parse(response.Content!);
            string token = json.RootElement.GetProperty("access_token").GetString()!;

            _cachedToken = token;
            _tokenExpiry = DateTime.UtcNow.AddMinutes(55);

            return _cachedToken;
        }

        /// <summary>
        /// Approves a user by setting their metadata to approved and assigns a role.
        /// </summary>
        /// <param name="userId">The Auth0 user ID to approve.</param>
        /// <param name="role">The role to assign to the user.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the approval or role assignment fails.</exception>
        public async Task ApproveUserAsync(string userId, string role)
        {
            string token = await GetManagementTokenAsync();

            RestClient client = new RestClient($"https://{_domain}/api/v2/users/{Uri.EscapeDataString(userId)}");
            RestRequest request = new RestRequest();
            request.Method = Method.Patch;
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(new { app_metadata = new { approved = true } }); 

            RestResponse response = await client.ExecuteAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new InvalidOperationException($"Failed to approve user: {response.StatusCode}");
            }

            await AssignRoleToUserAsync(userId, role);
        }

        /// <summary>
        /// Retrieves all unapproved users with optional search and paging.
        /// </summary>
        /// <param name="pageNr">The page number to retrieve (1-based).</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <param name="search">Optional search string for filtering users by email.</param>
        /// <returns>A <see cref="Task{Tuple}"/> containing the list of unapproved users and the total count.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the request fails.</exception>
        public async Task<(IEnumerable<Auth0User> Items, int TotalCount)> GetAllUnapprovedUsersPaged(int pageNr, int pageSize, string search)
        {
            string token = await GetManagementTokenAsync();
            string baseUrl = $"https://{_domain}/api/v2/users";
            string query = $"q=app_metadata.approved:false";

            if (!string.IsNullOrWhiteSpace(search))
            {
                query += $" AND email:*{search}*";
            }

            query += $"&search_engine=v3&page={pageNr - 1}&per_page={pageSize}&include_totals=true";

            RestClient client = new RestClient(baseUrl);
            RestRequest request = new RestRequest($"?{query}", Method.Get);
            request.AddHeader("Authorization", $"Bearer {token}");
            RestResponse response = await client.ExecuteAsync(request);

            if (!response.IsSuccessful)
            {
                throw new InvalidOperationException("Failed to list users.");
            }

            using JsonDocument doc = JsonDocument.Parse(response.Content!);
            JsonElement usersElement = doc.RootElement.GetProperty("users");
            int totalCount = doc.RootElement.GetProperty("total").GetInt32();

            List<Auth0User> users = JsonSerializer.Deserialize<List<Auth0User>>(usersElement.GetRawText(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new();

            return (users, totalCount);
        }

        /// <summary>
        /// Assigns a role to a specific user in Auth0.
        /// </summary>
        /// <param name="userId">The Auth0 user ID.</param>
        /// <param name="role">The role to assign.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <exception cref="InvalidOperationException">Thrown if role assignment fails.</exception>
        private async Task AssignRoleToUserAsync(string userId, string role)
        {
            string token = await GetManagementTokenAsync();
            RestClient client = new RestClient($"https://{_domain}/api/v2/users/{Uri.EscapeDataString(userId)}/roles");
            RestRequest request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(new { roles = new[] { role } });
            RestResponse response = await client.ExecuteAsync(request);

            if (response.StatusCode != HttpStatusCode.NoContent)
            {
                throw new InvalidOperationException($"Failed to assign role: {response.StatusCode} - {response.Content}");
            }
        }

        /// <summary>
        /// Retrieves all roles defined in Auth0.
        /// </summary>
        /// <returns>A <see cref="Task{IEnumerable{Auth0Role}}"/> containing the list of roles.</returns>
        /// <exception cref="InvalidOperationException">Thrown if retrieving roles fails.</exception>
        public async Task<IEnumerable<Auth0Role>> GetRoles()
        {
            string token = await GetManagementTokenAsync();
            RestClient client = new RestClient($"https://{_domain}/api/v2/roles");
            RestRequest request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddHeader("content-type", "application/json");
            RestResponse response = await client.ExecuteAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine($"Failed to get roles: {response.StatusCode} - {response.Content}");
                throw new InvalidOperationException($"Failed to get roles: {response.StatusCode} - {response.Content}");
            }

            List<Auth0Role>? roles = JsonSerializer.Deserialize<List<Auth0Role>>(response.Content!, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new();

            return roles ?? new List<Auth0Role>();
        }

        /// <summary>
        /// Retrieves a user from Auth0 by their user ID.
        /// </summary>
        /// <param name="userId">The Auth0 user ID.</param>
        /// <returns>A <see cref="Task{Auth0User}"/> representing the user, or null if not found.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the request fails for other reasons.</exception>
        public async Task<Auth0User?> GetUserByIdAsync(string userId)
        {
            string token = await GetManagementTokenAsync();

            RestClient client = new RestClient($"https://{_domain}/api/v2/users/{Uri.EscapeDataString(userId)}");
            RestRequest request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddHeader("content-type", "application/json");

            RestResponse response = await client.ExecuteAsync(request);

            if (!response.IsSuccessful)
            {
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }

                throw new InvalidOperationException($"Failed to get user: {response.StatusCode} - {response.Content}");
            }

            Auth0User? user = JsonSerializer.Deserialize<Auth0User>(response.Content!, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return user;
        }

        /// <summary>
        /// Deletes a user in Auth0 by their user ID.
        /// </summary>
        /// <param name="userId">The Auth0 user ID to delete.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <exception cref="InvalidOperationException">Thrown if deletion fails.</exception>
        public async Task DeleteUserAsync(string userId)
        {
            string token = await GetManagementTokenAsync();

            RestClient client = new RestClient($"https://{_domain}/api/v2/users/{Uri.EscapeDataString(userId)}");
            RestRequest request = new RestRequest();
            request.Method = Method.Delete;
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddHeader("content-type", "application/json");

            RestResponse response = await client.ExecuteAsync(request);

            if (response.StatusCode != HttpStatusCode.NoContent)
            {
                throw new InvalidOperationException($"Failed to delete user: {response.StatusCode} - {response.Content}");
            }
        }
    }
}
