using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Jostic.Rusia2018.Application.Interface.UseCases;
using Jostic.Rusia2018.Application.UseCases.Users;
using Jostic.Rusia2018.Application.UseCases.Grupos;
using System.Reflection;
using Jostic.Rusia2018.Application.UseCases.Paises;

namespace Jostic.Rusia2018.Application.UseCases
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IUsersApplication, UsersApplication>();
            services.AddScoped<IGrupoApplication, GrupoApplication>();
            services.AddScoped<IPaisApplication, PaisApplication>();

            return services;
        }
    }
}
