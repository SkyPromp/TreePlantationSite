using System.Security.Cryptography.X509Certificates;
using AP.BTP.WebAppMaintenance.Components;
using AP.BTP.Web.Authentication;
using AP.BTP.WebAppMaintenance.Extentions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using AP.BTP.Web.Shared.Components;

namespace AP.BTP.WebAppMaintenance
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddBlazorBootstrap();

            builder.Services.AddHttpContextAccessor();

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
                // Custom handler to add the access token as Bearer token
                return new AuthTokenHandler(provider.GetRequiredService<IHttpContextAccessor>());
            });

            builder.Services.AddAuth0Authentication(builder.Configuration);

            builder.Services.Configure<JwtBearerOptions>(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
                };
            });

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapAuth0Endpoints();

            app.UseRedirectToWelcomeWhenUnautenticated();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddAdditionalAssemblies(typeof(AppRouter).Assembly);          

            app.Run();
        }
    }
}
