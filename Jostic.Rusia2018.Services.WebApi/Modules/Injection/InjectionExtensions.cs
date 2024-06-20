using Jostic.Rusia2018.Services.WebApi.Modules.GlobalException;
using Jostic.Rusia2018.Transversal.Common;
using Jostic.Rusia2018.Transversal.Logging;

namespace Jostic.Rusia2018.Services.WebApi.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);        
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddTransient<GlobalExceptionHandler>();
            return services;
        }
    }
}
