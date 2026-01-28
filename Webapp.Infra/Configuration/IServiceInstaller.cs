using Microsoft.Extensions.DependencyInjection;

namespace Infra.Configuration;

public interface IServiceInstaller
{
    void Install(IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration);
}
