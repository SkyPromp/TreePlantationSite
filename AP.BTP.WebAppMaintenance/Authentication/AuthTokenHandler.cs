using Microsoft.AspNetCore.Authentication;
using System.Net.Http.Headers;

namespace AP.BTP.WebAppMaintenance.Authentication
{
    /// <summary>
    /// A <see cref="DelegatingHandler"/> that automatically adds the Auth0 access token
    /// from the current HTTP context to outgoing HTTP requests as a Bearer token.
    /// </summary>
    public class AuthTokenHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthTokenHandler"/> class.
        /// </summary>
        /// <param name="httpContextAccessor">
        /// Provides access to the current <see cref="HttpContext"/>, which is used to retrieve the access token.
        /// </param>
        public AuthTokenHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Sends an HTTP request asynchronously, attaching the access token from the current context
        /// to the Authorization header if available.
        /// </summary>
        /// <param name="request">The HTTP request message to send.</param>
        /// <param name="cancellationToken">A cancellation token to cancel operation.</param>
        /// <returns>A <see cref="Task{HttpResponseMessage}"/> representing the response.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if no access token is available in the current HTTP context.
        /// </exception>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpContext? context = _httpContextAccessor.HttpContext;

            if (context != null)
            {
                string? accessToken = await context.GetTokenAsync("access_token");

                if (!string.IsNullOrEmpty(accessToken))
                {
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
