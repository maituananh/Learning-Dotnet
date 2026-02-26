using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Webapp.Application.Abstractions;

namespace Webapp.Infra.Configuration;

internal class AppSettingsInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        var appSettings = new AppSettings();
        configuration.Bind(appSettings);

        var validator = new AppSettingsValidator();
        var validationResult = validator.Validate(appSettings);

        if (!validationResult.IsValid)
        {
            throw new Exception("Invalid app settings: " + string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)));
        }

        services.AddSingleton(appSettings);
    }
}
