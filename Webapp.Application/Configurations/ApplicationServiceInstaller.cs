using Application.Usecases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Webapp.Application.Abstractions;
using Webapp.Application.Usecases;

namespace Webapp.Application.Configurations;

public class ApplicationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<CreateUserHandler>();
        services.AddScoped<GetGroupByIdHandler>();
        services.AddScoped<AssignUserToGroupHandler>();
        services.AddScoped<AuthenHandler>();
        services.AddScoped<GetUserHandler>();
    }
}
