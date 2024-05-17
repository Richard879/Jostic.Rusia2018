using Jostic.Rusia2018.Application.Validator;

namespace Jostic.Rusia2018.Services.WebApi.Modules.Validator
{
    public static class ValidatorExtensions
    {
        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            services.AddTransient<UserDtoValidator>();
            return services;
        }
    }
}
