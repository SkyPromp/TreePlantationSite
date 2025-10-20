namespace AP.BTP.WebApp.Extentions
{
    public static class MiddlewareExtentions
    {
        private static readonly string[] _anonymousPaths =
{
            "/welcome",
            "/access-denied",
            "/register",
            "/login",
            "/callback",
            "/logout",
            "/_framework",
            "/_content",
            "/css"
        };
        public static IApplicationBuilder UseRedirectToWelcomeWhenUnautenticated(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                PathString path = context.Request.Path;

                // Skip authentication check for allowed paths
                if (_anonymousPaths.Any(p => path.StartsWithSegments(p)))
                {
                    await next();
                    return;
                }

                // Redirect if unauthenticated
                if (!(context.User.Identity?.IsAuthenticated ?? false))
                {
                    context.Response.Redirect("/welcome");
                    return;
                }
                await next();
            });
            return app;
        }
    }
}
