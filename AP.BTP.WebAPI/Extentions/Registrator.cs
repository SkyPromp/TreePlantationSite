using AP.BTP.WebAPI.Middleware;

namespace AP.BTP.WebAPI.Extentions
{
    /// <summary>
    /// Provides extension methods for <see cref="IApplicationBuilder"/> to register custom middlewares.
    /// </summary>
    public static class Registrator
    {
        /// <summary>
        /// Registers the <see cref="ExceptionHandlingMiddleware"/> in the application's middleware pipeline.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> instance to add the middleware to.</param>
        /// <returns>The <see cref="IApplicationBuilder"/> instance for chaining.</returns>
        public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            return app;
        }

        /// <summary>
        /// Registers the <see cref="SwaggerBypassAuthMiddleware"/> in the application's middleware pipeline.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> instance to add the middleware to.</param>
        /// <returns>The <see cref="IApplicationBuilder"/> instance for chaining.</returns>
        public static IApplicationBuilder UseSwaggerBypassAuth(this IApplicationBuilder app)
        {
            return app.UseMiddleware<SwaggerBypassAuthMiddleware>();
        }
    }
}
