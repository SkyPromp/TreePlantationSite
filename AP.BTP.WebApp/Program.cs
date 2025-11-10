using System.Security.Cryptography.X509Certificates;
using AP.BTP.WebApp.Auth0;
using AP.BTP.WebApp.Authentication;
using AP.BTP.WebApp.Components;
using AP.BTP.WebApp.Extentions;

namespace AP.BTP.WebApp
{
    /// <summary>
    /// The entry point for the Blazor client application.
    /// Configures services, HTTP clients, authentication, and middleware, then starts the web application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Application entry point. Builds and runs the Blazor WebAssembly server-side application.
        /// </summary>
        /// <param name="args">Command-line arguments passed to the application.</param>
        /// <remarks>
        /// This method performs the following actions:
        /// <list type="bullet">
        /// <item>
        /// <description>Adds Razor Components services and server-side interactive components.</description>
        /// </item>
        /// <item>
        /// <description>Registers <see cref="IHttpContextAccessor"/> to access HTTP context in services.</description>
        /// </item>
        /// <item>
        /// <description>Configures an HTTP client named "BTPApi" with base URL from configuration, optionally trusting a custom certificate, and attaches a custom <see cref="AuthTokenHandler"/> to include access tokens in requests.</description>
        /// </item>
        /// <item>
        /// <description>Adds Auth0 authentication services with configuration options from the app settings.</description>
        /// </item>
        /// <item>
        /// <description>Builds the <see cref="WebApplication"/> and configures the HTTP request pipeline, including authentication, authorization, static files, antiforgery, and custom middleware for redirecting unauthenticated users.</description>
        /// </item>
        /// <item>
        /// <description>Maps Auth0 login, register, and logout endpoints.</description>
        /// </item>
        /// <item>
        /// <description>Maps Razor Components to the root App component and enables interactive server rendering.</description>
        /// </item>
        /// <item>
        /// <description>Runs the web application.</description>
        /// </item>
        /// </list>
        /// </remarks>
        /// <example>
        /// <code>
        /// dotnet run
        /// </code>
        /// Starts the Blazor client app with server-side components and authentication configured.
        /// </example>
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
