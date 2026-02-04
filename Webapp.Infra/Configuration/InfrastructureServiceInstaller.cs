using Application.Configurations;
using Application.Repositories;
using Application.Repository;
using Application.Usecases;
using Infra.Configuration;
using Infra.Configurations;
using Infra.Repositories;
using Infra.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Webapp.Infra.Configuration
{
    internal class InfrastructureServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IGroupRepository), typeof(GroupRepository));
            services.AddScoped(typeof(IGroupUserRepository), typeof(GroupUserRepository));
            services.AddScoped(typeof(IIdentityRepository), typeof(IdentityRepository));

            services.AddScoped<CreateUserHandler>();
            services.AddScoped<GetGroupByIdHandler>();
            services.AddScoped<AssignUserToGroupHandler>();
            services.AddScoped<AuthenHandler>();
        }
    }
}
