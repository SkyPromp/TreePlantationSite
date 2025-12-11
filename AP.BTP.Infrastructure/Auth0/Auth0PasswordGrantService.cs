using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Text.Json;

namespace AP.BTP.Infrastructure.Auth0
{
    /// <summary>
    /// Service for authenticating users via Auth0 using the password grant flow.
    /// </summary>
    public class Auth0PasswordGrantService : IAuth0PasswordGrantService
    {
        private readonly IConfiguration _config;
        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };


        /// <summary>
        /// Initializes a new instance of the <see cref="Auth0PasswordGrantService"/> class with configuration values.
        /// </summary>
        /// <param name="config">The configuration containing Auth0 credentials.</param>
        public Auth0PasswordGrantService(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// Authenticates a user with Auth0 using their email and password, returning an access token if successful.
        /// </summary>
        /// <param name="email">The email address of the user attempting to log in.</param>
        /// <param name="password">The password of the user attempting to log in.</param>
        /// <returns>
        /// A task that returns a <see cref="TokenResponseDto"/> containing the access token and related authentication information
        /// if the login is successful; otherwise, null.
        /// </returns>
        public async Task<TokenResponseDto?> LoginAsync(string email, string password)
        {
            RestClient client = new RestClient($"https://{_config["AUTH0:DOMAIN"]}/oauth/token");
            RestRequest request = new RestRequest();
            request.Method = Method.Post;

            request.AddJsonBody(new
            {
                grant_type = "password",
                username = email,
                password = password,
                audience = _config["AUTH0:AUDIENCE"],
                client_id = _config["AUTH0:CLIENT_ID"],
                client_secret = _config["AUTH0:CLIENT_SECRET"],
                scope = "openid profile email"
            });

            RestResponse response = await client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                return null;

            TokenResponseDto? tokenResponse = JsonSerializer.Deserialize<TokenResponseDto>(response.Content!, _jsonOptions);

            return tokenResponse;
        }
    }
}