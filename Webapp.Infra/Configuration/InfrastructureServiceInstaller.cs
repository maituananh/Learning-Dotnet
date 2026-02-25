using Domain.Repositories;
using Domain.Repository;
using Infra.Configurations;
using Infra.Repositories;
using Infra.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Webapp.Application.Abstractions;
using Webapp.Infra.Repositories;

namespace Webapp.Infra.Configuration;

internal class InfrastructureServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

        services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
        services.Decorate(typeof(IUserRepository), typeof(CacheUserRepository));

        services.AddScoped(typeof(IGroupRepository), typeof(GroupRepository));
        services.AddScoped(typeof(IGroupUserRepository), typeof(GroupUserRepository));
        services.AddScoped(typeof(IIdentityRepository), typeof(IdentityRepository));
    }
}
