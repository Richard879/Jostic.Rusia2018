namespace Jostic.Rusia2018.Application.Interface.UseCases
{
    public interface ICacheable
    {
        //bool BypassCache { get; }
        string CacheKey { get; }
        int SlidingExpirationInMinutes { get; }
        int AbsoluteExpirationInMinutes { get; }
    }
}