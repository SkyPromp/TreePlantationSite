using Microsoft.AspNetCore.Authentication;
using System.Net.Http.Headers;

namespace AP.BTP.WebApp.Authentication
{
    /// <summary>
    /// A <see cref="DelegatingHandler"/> that automatically attaches the current user's access token
    /// from the <see cref="HttpContext"/> to outgoing HTTP requests as a Bearer token.
    /// </summary>
    public class AuthTokenHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthTokenHandler"/> class.
        /// </summary>
        /// <param name="httpContextAccessor">The <see cref="IHttpContextAccessor"/> used to access the current HTTP context.</param>
        public AuthTokenHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Intercepts outgoing HTTP requests and adds the Authorization header with the Bearer token
        /// retrieved from the current HTTP context, if available.
        /// </summary>
        /// <param name="request">The <see cref="HttpRequestMessage"/> to send.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel operation.</param>
        /// <returns>A <see cref="Task{HttpResponseMessage}"/> representing the asynchronous operation.</returns>
        /// <exception cref="InvalidOperationException">Thrown when there is no access token available in the current context.</exception>
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
