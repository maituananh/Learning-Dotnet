using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Webapp.Application.Abstractions;

public interface IServiceInstaller
{
    void Install(IServiceCollection services, IConfiguration configuration);
}
