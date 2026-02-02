using Infra.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace API.Configurations.DI;

public static class DependencyInjection
{
    public static IServiceCollection InstallServices (this IServiceCollection services, 
        IConfiguration configuration,
        params Assembly[] assemblies)
    {
        IEnumerable<IServiceInstaller> serviceInstallers = assemblies.SelectMany(a => a.DefinedTypes)
             .Where(t => typeof(IServiceInstaller).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
             .Select(Activator.CreateInstance)
             .Cast<IServiceInstaller>();

        foreach (IServiceInstaller serviceInstaller in serviceInstallers) {
            serviceInstaller.Install(services, configuration);
        }

        return services;
    }
}
