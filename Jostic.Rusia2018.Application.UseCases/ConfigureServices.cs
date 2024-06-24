using FluentValidation;
using Jostic.Rusia2018.Application.Interface.UseCases;
using Jostic.Rusia2018.Application.UseCases.Common.Behaviours;
using Jostic.Rusia2018.Application.UseCases.Grupos;
using Jostic.Rusia2018.Application.UseCases.Paises;
using Jostic.Rusia2018.Application.UseCases.Users;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Jostic.Rusia2018.Application.UseCases
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            });
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IUsersApplication, UsersApplication>();
            services.AddScoped<IGrupoApplication, GrupoApplication>();
            services.AddScoped<IPaisApplication, PaisApplication>();

            return services;
        }
    }
}