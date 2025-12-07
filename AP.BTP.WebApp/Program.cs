using AP.BTP.Web.Shared.Authentication;
using AP.BTP.Web.Shared.Components;
using AP.BTP.WebApp.Components;
using AP.BTP.Web.Shared.Extentions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
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

            builder.Services.AddControllers();

            builder.Services.Configure<AppInfo>(builder.Configuration.GetSection("AppInfo"));

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
                options.TokenValidationParameters = new TokenValidationParameters
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

            app.MapControllers();

            app.MapAuthEndpoints(builder.Configuration);

            app.UseRedirectToWelcomeWhenUnautenticated();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddAdditionalAssemblies(typeof(AppRouter).Assembly);

            app.Run();
        }
    }
}
