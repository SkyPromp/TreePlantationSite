namespace AP.BTP.WebAppMaintenance.Extentions
{
    /// <summary>
    /// Provides middleware extension methods for handling unauthenticated user redirection.
    /// </summary>
    public static class MiddlewareExtentions
    {
    /// <summary>
    /// Defines the list of paths that can be accessed without authentication.
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
        /// Adds middleware to the application's request pipeline that automatically redirects
        /// unauthenticated users to the <c>/welcome</c> page, except for specific anonymous paths.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> to configure the middleware for.</param>
        /// <returns>
        /// The same <see cref="IApplicationBuilder"/> instance so that multiple calls can be chained.
        /// </returns>
        /// <remarks>
        /// This middleware inspects incoming HTTP requests and checks if the user is authenticated.
        /// If the request path is not part of the predefined anonymous paths and the user is not authenticated,
        /// the request is redirected to the <c>/welcome</c> page.
        /// <para>
        /// Example usage in <c>Program.cs</c>:
        /// <code>
        /// app.UseRedirectToWelcomeWhenUnautenticated();
        /// </code>
        /// </para>
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
