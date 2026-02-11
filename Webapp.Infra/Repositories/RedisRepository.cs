using Microsoft.Extensions.Caching.Distributed;
using Webapp.Application.Repositories;

namespace Webapp.Infra.Repositories;

public class RedisRepository(IDistributedCache cache) : ICacheRepository
{
    public async Task Save(
        string key,
        string data,
        long ttl = 5,
        long slidingExpiration = 5)
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentNullException(nameof(key));
        }

        var cacheEntryOptions = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(ttl),
            SlidingExpiration = TimeSpan.FromMinutes(slidingExpiration)
        };

        await cache.SetStringAsync(key, data, cacheEntryOptions);
    }

    public async Task<string?> Get(string key)
    {

        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentNullException(nameof(key));
        }

        return await cache.GetStringAsync(key);
    }
}
