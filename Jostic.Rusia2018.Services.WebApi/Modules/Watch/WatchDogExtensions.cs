using WatchDog;

namespace Jostic.Rusia2018.Services.WebApi.Modules.Watch
{
    public static class WatchDogExtensions
    {
        public static IServiceCollection addWatchDog(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddWatchDogServices(o =>
            {
                o.SetExternalDbConnString = configuration.GetConnectionString("NorthwindConnection");
                o.DbDriverOption = WatchDog.src.Enums.WatchDogDbDriverEnum.MSSQL;
                o.IsAutoClear = true;
                o.ClearTimeSchedule = WatchDog.src.Enums.WatchDogAutoClearScheduleEnum.Monthly;
            });

            return services;
        }
    }
}
