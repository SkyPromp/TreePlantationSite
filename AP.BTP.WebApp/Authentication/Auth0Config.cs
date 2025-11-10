using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using System.Text.RegularExpressions;

namespace AP.BTP.WebApp.Auth0
{
    /// <summary>
    /// Provides extension methods to configure Auth0 authentication and map related endpoints for the web application.
    /// </summary>
    public static class Auth0Config
    {
        /// <summary>
        /// Configures Auth0 authentication for the application, including login, logout, callback handling, and access token setup.
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
                        // Capture the Auth0 error
                        string? failureMessage = context.Failure?.Message;
                        string description = "You do not have access to this application.";

                        if (!string.IsNullOrEmpty(failureMessage))
                        {
                            // Attempt to extract error_description text
                            Match match = Regex.Match(failureMessage, @"error_description: '(.+?)'");

                            if (match.Success) description = match.Groups[1].Value;
                        }

                        // Redirect to access denied page, passing the description as query parameter
                        string redirectUrl = $"/access-denied?description={Uri.EscapeDataString(description)}";
                        context.Response.Redirect(redirectUrl);

                        // Stop the exception from propagating
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
                options.LoginPath = "/login";
                options.LogoutPath = "/logout";
            });

            return services;
        }


        /// <summary>
        /// Maps Auth0-related endpoints for login, registration, and logout to the <see cref="WebApplication"/>.
        /// </summary>
        /// <param name="app">The <see cref="WebApplication"/> to map endpoints to.</param>
        public static void MapAuth0Endpoints(this WebApplication app)
        {
            /// <summary>
            /// Initiates the login process via Auth0 and redirects the user after authentication.
            /// </summary>
            app.MapGet("/login", async (HttpContext context, string? redirectUri) =>
            {
                AuthenticationProperties authProps = new LoginAuthenticationPropertiesBuilder()
                    .WithRedirectUri(redirectUri ?? "/")
                    .Build();

                await context.ChallengeAsync(Auth0Constants.AuthenticationScheme, authProps);
            });

            /// <summary>
            /// Initiates the registration process via Auth0 and redirects the user after signup.
            /// </summary>
            app.MapGet("/register", async (HttpContext context, string? redirectUri) =>
            {
                AuthenticationProperties authProps = new LoginAuthenticationPropertiesBuilder()
                    .WithRedirectUri(redirectUri ?? "/")
                    .WithParameter("screen_hint", "signup")
                    .Build();

                await context.ChallengeAsync(Auth0Constants.AuthenticationScheme, authProps);
            });

            /// <summary>
            /// Logs out the user from both Auth0 and the local cookie-based session.
            /// </summary>
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
