using Application.Configurations;
using Application.Repository;
using Application.Usecases.CreateUserHandler;
using Application.Usecases.Group;
using Infra.Configuration;
using Infra.Configurations;
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
            services.AddScoped<CreateUserHandler>();
            services.AddScoped<GetGroupByIdHandler>();
        }
    }
}
