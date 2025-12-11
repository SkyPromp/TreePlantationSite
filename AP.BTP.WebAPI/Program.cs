using AP.BTP.Application.Extentions;
using AP.BTP.Infrastructure.Context;
using AP.BTP.Infrastructure.Extentions;
using AP.BTP.WebAPI.Extentions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace AP.BTP.WebAPI
{
    /// <summary>
    /// The main entry point of the application.
    /// Configures services, middleware, authentication, authorization, database migrations, and runs the web application.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Main method invoked at application startup.
        /// Sets up dependency injection, controllers, Swagger, JWT authentication, and applies database migrations.
        /// </summary>
        /// <param name="args">Command-line arguments passed to the application.</param>
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.RegisterApplication();
            builder.Services.RegisterInfrastructure(builder.Configuration);

            builder.Services.AddControllers(options =>
            {
                AuthorizationPolicy policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Configure JWT Bearer Authentication
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = $"https://{builder.Configuration["AUTH0:DOMAIN"]}/";
                options.Audience = $"{builder.Configuration["AUTH0:AUDIENCE"]}";
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = "name",
                    RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
                };
            });

            builder.Services.AddAuthorization();

            WebApplication app = builder.Build();

            // Apply migrations at startup
            using (IServiceScope scope = app.Services.CreateScope())
            {
                BtpContext db = scope.ServiceProvider.GetRequiredService<BtpContext>();

                // Retry a few times if SQL Server isn't ready yet
                int retryCount = 5;
                TimeSpan delay = TimeSpan.FromSeconds(5);
                for (int i = 0; i < retryCount; i++)
                {
                    try
                    {
                        db.Database.Migrate();
                        break; // success
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Database migration failed: {ex.Message}");
                        if (i == retryCount - 1) throw; // last attempt, rethrow
                        Thread.Sleep(delay);
                    }
                }
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseSwaggerBypassAuth();
            }

            app.UseErrorHandlingMiddleware();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
