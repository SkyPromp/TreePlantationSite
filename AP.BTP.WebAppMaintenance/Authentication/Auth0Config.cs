using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using System.Text.RegularExpressions;

namespace AP.BTP.WebAppMaintenance.Auth0
{
    public static class Auth0Config
    {
        public static IServiceCollection AddAuth0Authentication(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuth0WebAppAuthentication(options =>
            {
                options.Domain = config["Auth0:Domain"]!;
                options.ClientId = config["Auth0:ClientId"]!;
                options.ClientSecret = config["Auth0:ClientSecret"]!;
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
                            if (match.Success)
                                description = match.Groups[1].Value;
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
                options.Audience = config["Auth0:Audience"];
            });

            services.Configure<CookieAuthenticationOptions>(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.LoginPath = "/login";
                options.LogoutPath = "/logout";
            });

            return services;
        }

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
