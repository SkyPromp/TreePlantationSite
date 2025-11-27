using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
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
        /// Assigns a role to a specific user in Auth0.
        /// </summary>
        /// <param name="userId">The Auth0 user ID.</param>
        /// <param name="role">The role to assign.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <exception cref="InvalidOperationException">Thrown if role assignment fails.</exception>
        public async Task AssignRoleToUserAsync(string userId, string role)
        {
            string token = await GetManagementTokenAsync();

            IEnumerable<Auth0RoleDTO> roles = await GetRoles();

            string? roleId = roles.FirstOrDefault(r => r.Name.Equals(role, StringComparison.OrdinalIgnoreCase))?.Id;

            if (roleId == null)
            {
                throw new InvalidOperationException($"Role '{role}' not found in Auth0.");
            }

            RestClient client = new RestClient($"https://{_domain}/api/v2/users/{Uri.EscapeDataString(userId)}/roles");
            RestRequest request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(new { roles = new[] { roleId } });
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
        private async Task<IEnumerable<Auth0RoleDTO>> GetRoles()
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

            List<Auth0RoleDTO>? roles = JsonSerializer.Deserialize<List<Auth0RoleDTO>>(response.Content!, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new();

            return roles ?? new List<Auth0RoleDTO>();
        }

        /// <summary>
        /// Retrieves a user from Auth0 by their user ID.
        /// </summary>
        /// <param name="userId">The Auth0 user ID.</param>
        /// <returns>A <see cref="Task{Auth0User}"/> representing the user, or null if not found.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the request fails for other reasons.</exception>
        public async Task<Auth0UserDTO?> GetUserByIdAsync(string userId)
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

            Auth0UserDTO? user = JsonSerializer.Deserialize<Auth0UserDTO>(response.Content!, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

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

        /// <summary>
        /// Creates a new user in Auth0.
        /// </summary>
        /// <param name="username">The user's name</param>
        /// <param name="email">The user's email.</param>
        /// <param name="password">The user's password.</param>
        /// <returns>A <see cref="Task{Auth0UserDTO}"/> containing the created user.</returns>
        /// <exception cref="InvalidOperationException">Thrown if user creation fails.</exception>
        public async Task<Auth0UserDTO?> CreateUserAsync(
            string username,
            string email,
            string password)
        {
            string token = await GetManagementTokenAsync();

            RestClient client = new RestClient($"https://{_domain}/api/v2/users");
            RestRequest request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddHeader("content-type", "application/json");


            request.AddJsonBody(new
            {
                username = username,
                email = email,
                password = password,
                connection = "Username-Password-Authentication"
            });

            RestResponse response = await client.ExecuteAsync(request);

            if (response.StatusCode != HttpStatusCode.Created)
            {
                throw new InvalidOperationException(
                    $"Failed to create user: {response.StatusCode} - {response.Content}");
            }

            return JsonSerializer.Deserialize<Auth0UserDTO>(response.Content!, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
