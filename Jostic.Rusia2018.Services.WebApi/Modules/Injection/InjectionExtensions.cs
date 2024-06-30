using Jostic.Rusia2018.Services.WebApi.Modules.GlobalException;

namespace Jostic.Rusia2018.Services.WebApi.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);        
            services.AddTransient<GlobalExceptionHandler>();
            return services;
        }
    }
}