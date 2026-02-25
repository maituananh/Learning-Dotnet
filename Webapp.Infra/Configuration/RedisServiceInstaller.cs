using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Webapp.Application.Abstractions;

namespace Webapp.Infra.Configuration;

public class RedisServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration.GetConnectionString("Redis");
            options.InstanceName = "LearningDotnetCore";
        });
    }
}
