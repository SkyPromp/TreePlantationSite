using AP.BTP.Application.Interfaces;
using AP.BTP.Infrastructure.Auth0;
using AP.BTP.Infrastructure.Context;
using AP.BTP.Infrastructure.Repositories;
using AP.BTP.Infrastructure.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AP.BTP.Infrastructure.Extentions
{
    /// <summary>
    /// Provides extension methods to register infrastructure services into the dependency injection container.
    /// </summary>
    public static class Registrator
    {
        /// <summary>
        /// Registers all infrastructure-related services, including the database context, repositories, and external services.
        /// </summary>
        /// <param name="services">The service collection to register services into.</param>
        /// <param name="configuration">The application configuration used for retrieving settings, such as the database connection string.</param>
        /// <returns>The updated <see cref="IServiceCollection"/> instance.</returns>
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterDbContext(configuration);
            services.RegisterRepositories();
            services.AddScoped<IAuth0ManagementService, Auth0ManagementService>();
            services.AddScoped<IAuth0PasswordGrantService, Auth0PasswordGrantService>();

            return services;
        }

        /// <summary>
        /// Registers the application's <see cref="BtpContext"/> with SQL Server using connection string and retry policy configuration.
        /// </summary>
        /// <param name="services">The service collection to register services into.</param>
        /// <param name="configuration">The application configuration used to retrieve the connection string named "Default".</param>
        /// <returns>The updated <see cref="IServiceCollection"/> instance.</returns>
        public static IServiceCollection RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BtpContext>(options =>
                        options.UseSqlServer(configuration.GetConnectionString("Default"),
                        sqlOptions => sqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null))
            );

            return services;
        }

        /// <summary>
        /// Registers all repository implementations and the unit of work into the dependency injection container.
        /// </summary>
        /// <param name="services">The service collection to register services into.</param>
        /// <returns>The updated <see cref="IServiceCollection"/> instance.</returns>
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPlantationSiteRepository, PlantationSiteRepository>();
            services.AddScoped<ITreeRepository, TreeRepository>();
            services.AddScoped<IZoneRepository, ZoneRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITaskListRepository, TaskListRepository>();
            services.AddScoped<ITaskItemRepository, TaskItemRepository>();
            services.AddScoped<ITreePictureRepository, TreePictureRepository>();

            return services;
        }
    }
}
