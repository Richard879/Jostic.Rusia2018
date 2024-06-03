using Microsoft.Extensions.Options;

namespace Jostic.Rusia2018.Services.WebApi.Modules.Caching
{
    public static class CachingExtensions
    {
        public static IServiceCollection AddCaching(this IServiceCollection services)
        {
            string myPolicy = "policyApiCaching";

            services.AddOutputCache(options => options.AddBasePolicy(builder => builder.Expire(TimeSpan.FromSeconds(30))));
            services.AddOutputCache(options => options.AddPolicy(myPolicy, policyBuilder => policyBuilder.Expire(TimeSpan.FromSeconds(10)).Tag("policyApiCaching_Tag")));
            return services;
        }
    }
}