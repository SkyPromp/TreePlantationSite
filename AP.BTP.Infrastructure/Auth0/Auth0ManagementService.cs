using AP.BTP.Application.CQRS.Users;
using AP.BTP.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<Auth0ManagementService> _logger;

        public Auth0ManagementService(IConfiguration config, ILogger<Auth0ManagementService> logger)
        {
            _logger = logger;
            _domain = config["AUTH0:DOMAIN"] ?? throw new ArgumentNullException("AUTH0:DOMAIN");
            _clientId = config["AUTH0:MANAGEMENT_CLIENT_ID"] ?? throw new ArgumentNullException("AUTH0:MANAGEMENT_CLIENT_ID");
            _clientSecret = config["AUTH0:MANAGEMENT_CLIENT_SECRET"] ?? throw new ArgumentNullException("AUTH0:MANAGEMENT_CLIENT_SECRET");
            _audience = $"https://{_domain}/api/v2/";
        }

        public async Task<string> GetManagementTokenAsync()
        {
            RestClient client = new RestClient($"https://{_domain}/oauth/token");
            RestRequest request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("content-type", "application/json");

            var body = new
            {
                client_id = _clientId,
                client_secret = _clientSecret,
                audience = _audience,
                grant_type = "client_credentials"
            };

            request.AddJsonBody(body);

            RestResponse response = await client.ExecuteAsync(request);

            if (!response.IsSuccessful)
            {
                _logger.LogError("Auth0 token request failed: {StatusCode} - {Content}", response.StatusCode, response.Content);
                throw new InvalidOperationException($"Failed to get Auth0 management token: {response.StatusCode}");
            }

            JsonDocument json = JsonDocument.Parse(response.Content);
            return json.RootElement.GetProperty("access_token").GetString()!;
        }

        public async Task ApproveUserAsync(string userId)
        {
            string token = await GetManagementTokenAsync();

            RestClient client = new RestClient($"https://{_domain}/api/v2/users/{Uri.EscapeDataString(userId)}");
            RestRequest request = new RestRequest();
            request.Method = Method.Patch;
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddHeader("content-type", "application/json");

            var body = new
            {
                app_metadata = new { approved = true }
            };
            request.AddJsonBody(body);

            RestResponse response = await client.ExecuteAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                _logger.LogError("Approving user failed: {StatusCode} - {Content}", response.StatusCode, response.Content);
                throw new InvalidOperationException($"Failed to approve user: {response.StatusCode}");
            }
        }

        public async Task<List<Auth0User>> ListUnapprovedUsersAsync()
        {
            string token = await GetManagementTokenAsync();

            RestClient client = new RestClient($"https://{_domain}/api/v2/users?q=app_metadata.approved:false&search_engine=v3");
            RestRequest request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("Authorization", $"Bearer {token}");

            RestResponse response = await client.ExecuteAsync(request);

            if (!response.IsSuccessful)
            {
                _logger.LogError("List users failed: {StatusCode} - {Content}", response.StatusCode, response.Content);
                throw new InvalidOperationException("Failed to list users.");
            }

            List<Auth0User> users = JsonSerializer.Deserialize<List<Auth0User>>(response.Content!,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new();

            return users;
        }
    }
}
