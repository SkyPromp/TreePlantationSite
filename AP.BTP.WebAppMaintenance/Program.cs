using AP.BTP.Contracts.DTOs;
using AP.BTP.Web.Authentication;
using AP.BTP.Web.Shared.Components;
using AP.BTP.WebAppMaintenance.Components;
using AP.BTP.WebAppMaintenance.Extentions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

namespace AP.BTP.WebAppMaintenance
{
    /// <summary>
    /// Entry point and startup configuration for the Blazor Server application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main entry point of the application. Configures and runs the web application host.
        /// </summary>
        /// <param name="args">Command-line arguments passed to the application.</param>
        /// <remarks>
        /// This method performs the following steps:
        /// <list type="number">
        /// <item><description>Builds the <see cref="WebApplication"/> host using <see cref="WebApplication.CreateBuilder"/>.</description></item>
        /// <item><description>Registers services such as Razor Components, Blazor Bootstrap, and HTTP clients.</description></item>
        /// <item><description>Configures an HTTP client named <c>BTPApi</c> for communicating with the backend API, 
        /// optionally trusting a custom SSL certificate defined via the <c>API_CERT_PATH</c> configuration setting.</description></item>
        /// <item><description>Adds Auth0 authentication and configures JWT role claim mapping.</description></item>
        /// <item><description>Sets up middleware for authentication, authorization, static file handling, and error management.</description></item>
        /// <item><description>Applies a custom middleware that redirects unauthenticated users to the <c>/welcome</c> page.</description></item>
        /// <item><description>Maps and runs the Blazor components that define the application UI.</description></item>
        /// </list>
        /// </remarks>
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddBlazorBootstrap();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddMemoryCache();

            builder.Services.AddHttpClient("BTPApi", client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["Api:BaseUrl"]!);
            })
            .ConfigurePrimaryHttpMessageHandler(() =>
            {
                HttpClientHandler handler = new HttpClientHandler();

                string? certPath = builder.Configuration["API_CERT_PATH"];
                if (!string.IsNullOrEmpty(certPath) && File.Exists(certPath))
                {
                    X509Certificate2 trustedCert = new X509Certificate2(certPath);
                    X509Store store = new X509Store(StoreName.Root, StoreLocation.CurrentUser);
                    store.Open(OpenFlags.ReadWrite);
                    store.Add(trustedCert);
                    store.Close();

                    handler.ServerCertificateCustomValidationCallback =
                        HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                    Console.WriteLine($"Using trusted certificate at {certPath}");
                }
                else
                {
                    Console.WriteLine("No certificate found, SSL verification remains strict");
                }

                return handler;
            }).AddHttpMessageHandler(provider =>
            {
                return new AuthTokenHandler(provider.GetRequiredService<IHttpContextAccessor>());
            });

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.LoginPath = "/login";
            });

            builder.Services.Configure<JwtBearerOptions>(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
                };
            });

            WebApplication app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();
            app.UseAntiforgery();

            // TODO login callback endpoint in apparte file steken (en ook andere auth configuraties)
            app.MapGet("/auth/login-callback", async (HttpContext context, [FromServices] IMemoryCache cache) =>
            {
                string key = context.Request.Query["key"].ToString();
                if (string.IsNullOrEmpty(key) || !cache.TryGetValue<LoginResponseDTO>(key, out LoginResponseDTO? LoginResponse))
                {
                    return Results.BadRequest("Invalid or expired key.");
                }

                cache.Remove(key);

                if (LoginResponse == null)
                {
                    return Results.Unauthorized();
                }

                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

                string authority = $"https://{builder.Configuration["AUTH0:DOMAIN"]}/";
                string? audience = builder.Configuration["AUTH0:CLIENT_ID"];

                ConfigurationManager<OpenIdConnectConfiguration> configManager = new ConfigurationManager<OpenIdConnectConfiguration>(
                    $"{authority}.well-known/openid-configuration",
                    new OpenIdConnectConfigurationRetriever()
                );

                OpenIdConnectConfiguration openIdConfig = await configManager.GetConfigurationAsync(CancellationToken.None);

                TokenValidationParameters validationParameters = new TokenValidationParameters
                {
                    ValidIssuer = authority,
                    ValidAudience = audience,
                    IssuerSigningKeys = openIdConfig.SigningKeys,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(2)
                };

                try
                {
                    ClaimsPrincipal principal = handler.ValidateToken(LoginResponse.id_token, validationParameters, out SecurityToken? validatedToken);

                    List<Claim> claims = principal.Claims.Select(c =>
                    {
                        if (c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role")
                        {
                            return c.Value.Split(',').Select(r => new Claim(ClaimTypes.Role, r.Trim()));
                        }
                        return [new Claim(c.Type, c.Value)];
                    }).SelectMany(c => c).ToList();

                    claims.Add(new Claim("access_token", LoginResponse.access_token));
                    claims.Add(new Claim("id_token", LoginResponse.id_token));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, LoginResponse.UserId.ToString()));
                    claims.Add(new Claim(ClaimTypes.GivenName, LoginResponse.FirstName));
                    claims.Add(new Claim(ClaimTypes.Surname, LoginResponse.LastName));
                    claims.Add(new Claim(ClaimTypes.MobilePhone, LoginResponse.PhoneNumber));
                    claims.Add(new Claim(ClaimTypes.Email, LoginResponse.Email));

                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal cookiePrincipal = new ClaimsPrincipal(identity);

                    await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, cookiePrincipal);

                    return Results.Redirect("/");
                }
                catch (SecurityTokenValidationException)
                {
                    return Results.Unauthorized();
                }
            });


            // TODO: logout fixen en endpoint toevoegen

            app.UseRedirectToWelcomeWhenUnautenticated();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddAdditionalAssemblies(typeof(AppRouter).Assembly);

            app.Run();
        }
    }
}
