using AP.BTP.Application.Interfaces;
using AP.BTP.Infrastructure.Context;
using AP.BTP.Infrastructure.Repositories;
using AP.BTP.Infrastructure.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AP.BTP.Infrastructure.Extentions
{
    public static class Registrator
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterDbContext(configuration);
            services.RegisterRepositories();
            return services;
        }
        public static IServiceCollection RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BTPContext>(options =>
                        options.UseSqlServer(configuration.GetConnectionString("Default"),
                        sqlOptions => sqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null))
                    );

            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<ITreeRepository, TreeRepository>();
            return services;
        }
    }
}
