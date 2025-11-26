using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;

namespace AP.BTP.Web.Authentication
{
    /// <summary>
    /// Provides extension methods to configure Auth0 authentication and map related endpoints for the web application.
    /// </summary>
    public static class Auth0Config
    {
        /// <summary>
        /// Configures Auth0 authentication for the application, logout, callback handling.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add authentication services to.</param>
        /// <param name="config">The <see cref="IConfiguration"/> containing Auth0 settings.</param>
        /// <returns>The <see cref="IServiceCollection"/> for chaining further service registrations.</returns>
        public static IServiceCollection AddAuth0Authentication(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuth0WebAppAuthentication(options =>
            {
                options.Domain = config["AUTH0:DOMAIN"]!;
                options.ClientId = config["AUTH0:CLIENT_ID"]!;
                options.ClientSecret = config["AUTH0:CLIENT_SECRET"]!;
                options.CallbackPath = "/callback";
                options.OpenIdConnectEvents = new OpenIdConnectEvents
                {
                    OnRemoteFailure = context =>
                    {
                        string? failureMessage = context.Failure?.Message;
                        string description = "You do not have access to this application.";

                        if (!string.IsNullOrEmpty(failureMessage))
                        {
                            Match match = Regex.Match(failureMessage, @"error_description: '(.+?)'");

                            if (match.Success) description = match.Groups[1].Value;
                        }

                        string redirectUrl = $"/access-denied?description={Uri.EscapeDataString(description)}";
                        context.Response.Redirect(redirectUrl);

                        context.HandleResponse();

                        return Task.CompletedTask;
                    }
                };
            })
            .WithAccessToken(options =>
            {
                options.Audience = config["AUTH0:AUDIENCE"];
            });

            services.Configure<CookieAuthenticationOptions>(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.LogoutPath = "/logout";
            });

            return services;
        }


        /// <summary>
        /// Maps Auth0-related endpoints for logout to the <see cref="WebApplication"/>.
        /// </summary>
        /// <param name="app">The <see cref="WebApplication"/> to map endpoints to.</param>
        public static void MapAuth0Endpoints(this WebApplication app)
        {
            app.MapGet("/logout", async (HttpContext context) =>
            {
                AuthenticationProperties authProps = new LogoutAuthenticationPropertiesBuilder()
                    .WithRedirectUri("/")
                    .Build();

                await context.SignOutAsync(Auth0Constants.AuthenticationScheme, authProps);
                await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            });
        }
    }
}
