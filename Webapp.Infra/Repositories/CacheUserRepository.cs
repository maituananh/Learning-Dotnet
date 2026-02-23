using Application.Repository;
using Domain;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Webapp.Infra.Repositories;

public class CacheUserRepository : IUserRepository
{

    private readonly static string CACHE_KEY = "users";

    private readonly IUserRepository inner;
    private readonly IDistributedCache cache;
    private readonly DistributedCacheEntryOptions cacheEntryOptions;

    public CacheUserRepository(
        IUserRepository _inner,
        IDistributedCache _cache)
    {
        inner = _inner;
        cache = _cache;

        cacheEntryOptions = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
            SlidingExpiration = TimeSpan.FromMinutes(5)
        };
    }

    public async Task Delete(Guid id)
    {
        await inner.Delete(id);
        await cache.RemoveAsync($"{CACHE_KEY}:{id}");
    }

    public async Task<User?> FindByUsername(string username)
    {
        return await inner.FindByUsername(username);
    }

    public async Task<User?> GetById(User user)
    {
        var userCache = await cache.GetStringAsync($"{CACHE_KEY}:{user.Id}");

        Console.WriteLine($"found {user.Id} in cache: {userCache != null}");

        if (userCache == null)
        {
            var userFound = await inner.GetById(user);
            await cache.SetStringAsync($"{CACHE_KEY}:{user.Id}", JsonSerializer.Serialize(userFound), cacheEntryOptions);

            return userFound;
        }

        return JsonSerializer.Deserialize<User>(userCache);
    }

    public async Task Insert(User user)
    {
        await inner.Insert(user);
        await cache.SetStringAsync($"{CACHE_KEY}:{user.Id}", JsonSerializer.Serialize(user), cacheEntryOptions);
    }

    public async Task Update(User user)
    {
        await inner.Update(user);
        await cache.SetStringAsync($"{CACHE_KEY}:{user.Id}", JsonSerializer.Serialize(user), cacheEntryOptions);
    }
}
