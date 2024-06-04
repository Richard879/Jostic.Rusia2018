using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Jostic.Rusia2018.Application.Interface.UseCases;
using Jostic.Rusia2018.Application.UseCases.Users;
using Jostic.Rusia2018.Application.UseCases.Grupos;
using System.Reflection;

namespace Jostic.Rusia2018.Application.UseCases
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IUsersApplication, UsersApplication>();
            services.AddScoped<IGrupoApplication, GrupoApplication>();

            return services;
        }
    }
}
