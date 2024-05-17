namespace Jostic.Rusia2018.Services.WebApi.Modules.Feature
{
    public static class FeatureExtensions
    {
        public static IServiceCollection AddFeature(this IServiceCollection services, IConfiguration configuration)
        {
            string myPolicy = "policyApiEcommerce";

            services.AddCors(options => options.AddPolicy(myPolicy, builder => builder.WithOrigins(configuration["Config:OriginCors"]!)
                                                                                        .AllowAnyHeader()
                                                                                        .AllowAnyMethod()
                                                                                        .AllowAnyOrigin()));
            services.AddMvc();

            return services;
        }
    }
}
