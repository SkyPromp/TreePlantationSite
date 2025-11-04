using AP.BTP.Application.CQRS.Users;
using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.Records;
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

        public Auth0ManagementService(IConfiguration config)
        {
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

            request.AddJsonBody(new { app_metadata = new { approved = true } }); 

            RestResponse response = await client.ExecuteAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new InvalidOperationException($"Failed to approve user: {response.StatusCode}");
            }
        }

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

            List<Auth0User> users = JsonSerializer.Deserialize<List<Auth0User>>(usersElement.GetRawText(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new();

            return (users, totalCount);
        }
    }
}
