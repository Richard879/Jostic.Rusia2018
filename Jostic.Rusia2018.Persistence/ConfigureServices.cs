using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Persistence.Context;
using Jostic.Rusia2018.Persistence.Repositories;

namespace Jostic.Rusia2018.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<DapperContext>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IContinentRepository, ContinentRepository>();
            services.AddScoped<IPhaseRepository, PhaseRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}