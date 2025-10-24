using System.Security.Claims;
using Microsoft.Extensions.Primitives;

namespace AP.BTP.WebAPI.Middleware
{
    public class SwaggerBypassAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public SwaggerBypassAuthMiddleware(RequestDelegate next) => _next = next;

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
