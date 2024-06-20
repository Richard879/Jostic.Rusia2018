using Jostic.Rusia2018.Services.WebApi.Modules.GlobalException;

namespace Jostic.Rusia2018.Services.WebApi.Modules.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder AddMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<GlobalExceptionHandler>();
        }
    }
}