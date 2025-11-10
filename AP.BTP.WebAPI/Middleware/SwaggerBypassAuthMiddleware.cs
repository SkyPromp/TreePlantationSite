using System.Security.Claims;
using Microsoft.Extensions.Primitives;

namespace AP.BTP.WebAPI.Middleware
{
    /// <summary>
    /// Middleware that bypasses authentication for requests coming from the Swagger UI.
    /// Automatically injects a dummy authenticated user with an "Admin" role.
    /// </summary>
    public class SwaggerBypassAuthMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Initializes a new instance of the <see cref="SwaggerBypassAuthMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next middleware in the HTTP request pipeline.</param>
        public SwaggerBypassAuthMiddleware(RequestDelegate next) => _next = next;

        /// <summary>
        /// Invokes the middleware for the given <see cref="HttpContext"/>.
        /// If the request originates from the Swagger UI, a dummy authenticated user is created.
        /// </summary>
        /// <param name="context">The HTTP context for the current request.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Headers.TryGetValue("Referer", out StringValues referer) &&
                referer.ToString().Contains("/swagger", StringComparison.OrdinalIgnoreCase))
            {
                // Create a dummy authenticated user
                context.User = new ClaimsPrincipal(new ClaimsIdentity(
                    [new Claim(ClaimTypes.Role, "Admin")], "SwaggerBypass"
                ));
            }

            await _next(context);
        }
    }
}
