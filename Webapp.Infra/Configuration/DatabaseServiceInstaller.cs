using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Webapp.Application.Abstractions;

namespace Infra.Configuration;

internal class DatabaseServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(option =>
        {
            option.UseSqlServer(configuration.GetConnectionString("DatabaseUrl"));
            option.EnableDetailedErrors(true);
            option.EnableSensitiveDataLogging(true);
        });
    }
}
