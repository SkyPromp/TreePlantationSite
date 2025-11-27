namespace AP.BTP.WebApp.Extentions
{
    /// <summary>
    /// Provides extension methods for configuring custom middleware in the application pipeline.
    /// </summary>
    public static class MiddlewareExtentions
    {
        /// <summary>
        /// Paths that are allowed to be accessed anonymously without authentication.
        /// </summary>
        private static readonly string[] _anonymousPaths = {
            "/welcome",
            "/access-denied",
            "/register",
            "/login",
            "/callback",
            "/logout",
            "/_framework",
            "/_content",
            "/css",
            "/_blazor",
            "/auth/login-callback"
        };

        /// <summary>
        /// Adds middleware to the application pipeline that redirects unauthenticated users
        /// to the "/welcome" page if they try to access protected routes.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> instance to configure the middleware on.</param>
        /// <returns>The <see cref="IApplicationBuilder"/> with the middleware configured.</returns>
        /// <remarks>
        /// The middleware will bypass authentication checks for predefined anonymous paths,
        /// including static resources (/_framework, /_content, /css) and public pages
        /// like /welcome, /login, /logout, /register, /callback, and /access-denied.
        /// For any other path, if the user is not authenticated, they are redirected to "/welcome".
        /// </remarks>
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
