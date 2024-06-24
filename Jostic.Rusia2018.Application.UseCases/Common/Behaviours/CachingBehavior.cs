using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text;
using Jostic.Rusia2018.Application.Interface.UseCases;

namespace Jostic.Rusia2018.Application.UseCases.Common.Behaviours
{
    public class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ICacheable
    {
        public readonly ILogger<CachingBehavior<TRequest, TResponse>> _logger;
        public readonly IDistributedCache _distributedCache;

        public CachingBehavior(ILogger<CachingBehavior<TRequest, TResponse>> logger, IDistributedCache distributedCache)
        {
            _logger = logger;
            _distributedCache = distributedCache;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            TResponse response;
            //if (request.BypassCache) return await next();
            async Task<TResponse> GetResponseAndAddToCache()
            {
                response = await next();
                if (response != null)
                {
                    var slidingExpiration = request.SlidingExpirationInMinutes == 0 ? 30 : request.SlidingExpirationInMinutes;
                    var absoluteExpiration = request.AbsoluteExpirationInMinutes == 0 ? 60 : request.AbsoluteExpirationInMinutes;
                    var options = new DistributedCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromMinutes(slidingExpiration))
                        .SetAbsoluteExpiration(TimeSpan.FromMinutes(absoluteExpiration));

                    var serializedData = Encoding.Default.GetBytes(JsonSerializer.Serialize(response));
                    await _distributedCache.SetAsync(request.CacheKey, serializedData, options, cancellationToken);
                }
                return response;
            }
            var cachedResponse = await _distributedCache.GetAsync(request.CacheKey, cancellationToken);
            if (cachedResponse != null)
            {
                response = JsonSerializer.Deserialize<TResponse>(Encoding.Default.GetString(cachedResponse))!;
                _logger.LogInformation("fetched from cache with key : {CacheKey}", request.CacheKey);
                _distributedCache.Refresh(request.CacheKey);
            }
            else
            {
                response = await GetResponseAndAddToCache();
                _logger.LogInformation("added to cache with key : {CacheKey}", request.CacheKey);
            }
            return response;
        }
    }
}