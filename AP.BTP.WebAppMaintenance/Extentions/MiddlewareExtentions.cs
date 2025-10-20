namespace AP.BTP.WebAppMaintenance.Extentions
{
    public static class MiddlewareExtentions
    {
        public static IApplicationBuilder UseRedirectToWelcomeWhenUnautenticated(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                PathString path = context.Request.Path;

                // Allow anonymous access to /welcome and static files
                if (path.StartsWithSegments("/welcome") ||
                    path.StartsWithSegments("/access-denied") ||
                    path.StartsWithSegments("/_framework") ||
                    path.StartsWithSegments("/_content") ||
                    path.StartsWithSegments("/css") ||
                    path.StartsWithSegments("/login") ||
                    path.StartsWithSegments("/register") ||
                    path.StartsWithSegments("/callback") ||
                    path.StartsWithSegments("/logout"))
                {
                    await next();
                }
                else if (!(context.User.Identity?.IsAuthenticated ?? false))
                {
                    context.Response.Redirect("/welcome");
                }
                else
                {
                    await next();
                }
            });

            return app;
        }
    }
}
