using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Net;
using System.Text.Json;

namespace AP.BTP.Infrastructure.Auth0
{
    public class Auth0ManagementService : IAuth0ManagementService
    {
        private readonly string _domain;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _audience;

        private string? _cachedToken;
        private DateTime _tokenExpiry;

        public Auth0ManagementService(IConfiguration config)
        {
            _domain = config["AUTH0:DOMAIN"] ?? throw new ArgumentNullException("AUTH0:DOMAIN");
            _clientId = config["AUTH0:MANAGEMENT_CLIENT_ID"] ?? throw new ArgumentNullException("AUTH0:MANAGEMENT_CLIENT_ID");
            _clientSecret = config["AUTH0:MANAGEMENT_CLIENT_SECRET"] ?? throw new ArgumentNullException("AUTH0:MANAGEMENT_CLIENT_SECRET");
            _audience = $"https://{_domain}/api/v2/";
        }

        private async Task<string> GetManagementTokenAsync()
        {
            if (_cachedToken != null && DateTime.UtcNow < _tokenExpiry)
                return _cachedToken;

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

        public async Task<(IEnumerable<Auth0UserDTO> Items, int TotalCount)> GetAllUnapprovedUsersPaged(int pageNr, int pageSize, string search)
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

            List<Auth0UserDTO> users = JsonSerializer.Deserialize<List<Auth0UserDTO>>(usersElement.GetRawText(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new();
            return (users, totalCount);
        }

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

        public async Task<IEnumerable<Auth0RoleDTO>> GetRoles()
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

            List<Auth0RoleDTO>? roles = JsonSerializer.Deserialize<List<Auth0RoleDTO>>(response.Content!, 
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new();
            return roles ?? new List<Auth0RoleDTO>();
        }

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

            Auth0UserDTO? user = JsonSerializer.Deserialize<Auth0UserDTO>(response.Content!,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return user;
        }

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
            return;
        }
    }
}
