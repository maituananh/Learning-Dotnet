using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Webapp.API.Validations;
using Webapp.Application.Abstractions;

namespace Webapp.Application.Configuration;

public class FluentValidationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddValidatorsFromAssemblyContaining<AuthValidation>();
    }
}
