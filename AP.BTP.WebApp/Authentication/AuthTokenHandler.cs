using Microsoft.AspNetCore.Authentication;
using System.Net.Http.Headers;

namespace AP.BTP.WebApp.Authentication
{
    public class AuthTokenHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthTokenHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var context = _httpContextAccessor.HttpContext;
            if (context != null)
            {
                var accessToken = await context.GetTokenAsync("access_token");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    Console.WriteLine("access token: " + accessToken);
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
                else
                {
                    // Optionally handle the case where there is no access token
                    throw new InvalidOperationException("No access token available in the current context.");
                }
            }
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
