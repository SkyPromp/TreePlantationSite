using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace AP.BTP.WebApp.Auth0
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
                var authProps = new LoginAuthenticationPropertiesBuilder()
                    .WithRedirectUri(redirectUri ?? "/")
                    .Build();

                await context.ChallengeAsync(Auth0Constants.AuthenticationScheme, authProps);
            });

            app.MapGet("/register", async (HttpContext context, string? redirectUri) =>
            {
                var authProps = new LoginAuthenticationPropertiesBuilder()
                    .WithRedirectUri(redirectUri ?? "/")
                    .WithParameter("screen_hint", "signup")
                    .Build();

                await context.ChallengeAsync(Auth0Constants.AuthenticationScheme, authProps);
            });

            app.MapGet("/logout", async (HttpContext context) =>
            {
                var authProps = new LogoutAuthenticationPropertiesBuilder()
                    .WithRedirectUri("/")
                    .Build();

                await context.SignOutAsync(Auth0Constants.AuthenticationScheme, authProps);
                await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            });
        }
    }
}
