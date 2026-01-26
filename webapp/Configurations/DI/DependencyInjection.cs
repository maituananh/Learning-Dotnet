using Application.Repository;
using Infra.Configuration;
using Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Application.Usecases.User.CreateUserHandler;

namespace API.Configurations.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(option =>
        {
            option.UseSqlServer(configuration.GetConnectionString("url"));
        });

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<CreateUserHandler>();

        return services;
    }
}
