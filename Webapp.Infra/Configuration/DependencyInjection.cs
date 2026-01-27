using Infra.Configuration;
using Microsoft.EntityFrameworkCore;
using Application.Usecases.CreateUserHandler;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Application.Configurations;
using Infra.Configurations;
using Application.Repository;
using Infra.Repository;

namespace API.Configurations.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(option =>
        {
            option.UseSqlServer(configuration.GetConnectionString("url"));
        });

        //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
        services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
        services.AddScoped<CreateUserHandler>();

        return services;
    }
}
