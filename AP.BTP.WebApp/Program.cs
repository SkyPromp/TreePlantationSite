using System.Security.Cryptography.X509Certificates;
using AP.BTP.WebApp.Auth0;
using AP.BTP.WebApp.Authentication;
using AP.BTP.WebApp.Components;
using AP.BTP.WebApp.Extentions;

namespace AP.BTP.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

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
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
