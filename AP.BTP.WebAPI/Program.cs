using AP.BTP.Application.Extentions;
using AP.BTP.Infrastructure.Context;
using AP.BTP.Infrastructure.Extentions;
using AP.BTP.WebAPI.Extentions;
using Microsoft.EntityFrameworkCore;

namespace AP.BTP.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("Default");

            // Add services to the container.
            builder.Services.RegisterApplication();
            builder.Services.RegisterInfrastructure(builder.Configuration);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Apply migrations at startup
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<BTPContext>();

                // Retry a few times if SQL Server isn't ready yet
                var retryCount = 5;
                var delay = TimeSpan.FromSeconds(5);
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
            }
            app.UseErrorHandlingMiddleware();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
