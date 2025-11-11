using AP.BTP.Application.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AP.BTP.Application.Extentions
{
    /// <summary>
    /// Provides extension methods to register application services, such as MediatR, AutoMapper,
    /// FluentValidation, and pipeline behaviors, into the <see cref="IServiceCollection"/>.
    /// </summary>
    public static class Registrator
    {
        /// <summary>
        /// Registers the application services including MediatR handlers, AutoMapper profiles,
        /// FluentValidation validators, and the validation pipeline behavior.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to register services into.</param>
        /// <returns>The updated <see cref="IServiceCollection"/> with the application services registered.</returns>
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return services;
        }
    }
}
