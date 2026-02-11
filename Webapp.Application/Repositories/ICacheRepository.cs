namespace Webapp.Application.Repositories;

public interface ICacheRepository
{
    public Task Save(
        string key,
        string data,
        long ttl = 5,
        long slidingExpiration = 5);

    public Task<string?> Get(string key);
}
