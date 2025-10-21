using AP.BTP.WebAPI.Middleware;

namespace AP.BTP.WebAPI.Extentions
{
    public static class Registrator
    {
        public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            return app;
        }

        public static IApplicationBuilder UseSwaggerBypassAuth(this IApplicationBuilder app)
        {
            return app.UseMiddleware<SwaggerBypassAuthMiddleware>();
        }
    }
}
