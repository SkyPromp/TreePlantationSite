using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using System.Text.RegularExpressions;

namespace AP.BTP.WebAppMaintenance.Auth0
{
    /// <summary>
    /// Provides extension methods to configure Auth0 authentication and related endpoints for the application.
    /// </summary>
    public static class Auth0Config
    {
        /// <summary>
        /// Configures Auth0 authentication for the application using OpenID Connect.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to which authentication services are added.</param>
        /// <param name="config">The application configuration from which Auth0 settings are read.</param>
        /// <returns>The updated <see cref="IServiceCollection"/> instance for chaining.</returns>
        /// <remarks>
        /// This method performs the following actions:
        /// <list type="bullet">
        /// <item>
        /// <description>Sets up Auth0 domain, client ID, client secret, and callback path.</description>
        /// </item>
        /// <item>
        /// <description>Handles remote failures by redirecting users to an access-denied page with a descriptive message.</description>
        /// </item>
        /// <item>
        /// <description>Configures the access token audience for API calls.</description>
        /// </item>
        /// <item>
        /// <description>Configures cookie authentication login and logout paths.</description>
        /// </item>
        /// </list>
        /// </remarks>
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
        /// Maps Auth0 authentication-related endpoints for login, registration, and logout.
        /// </summary>
        /// <param name="app">The <see cref="WebApplication"/> instance to map endpoints onto.</param>
        /// <remarks>
        /// The mapped endpoints include:
        /// <list type="bullet">
        /// <item><description><c>/login</c> - Initiates Auth0 login challenge and optionally redirects after login.</description></item>
        /// <item><description><c>/register</c> - Initiates Auth0 signup challenge and optionally redirects after registration.</description></item>
        /// <item><description><c>/logout</c> - Signs out the user from Auth0 and the local cookie authentication scheme.</description></item>
        /// </list>
        /// </remarks>
        public static void MapAuth0Endpoints(this WebApplication app)
        {
            app.MapGet("/login", async (HttpContext context, string? redirectUri) =>
            {
                AuthenticationProperties authProps = new LoginAuthenticationPropertiesBuilder()
                    .WithRedirectUri(redirectUri ?? "/")
                    .Build();

                await context.ChallengeAsync(Auth0Constants.AuthenticationScheme, authProps);
            });

            app.MapGet("/register", async (HttpContext context, string? redirectUri) =>
            {
                AuthenticationProperties authProps = new LoginAuthenticationPropertiesBuilder()
                    .WithRedirectUri(redirectUri ?? "/")
                    .WithParameter("screen_hint", "signup")
                    .Build();

                await context.ChallengeAsync(Auth0Constants.AuthenticationScheme, authProps);
            });

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
