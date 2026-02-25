using Application.Configurations.Mappers.Profiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Webapp.Application.Abstractions;

namespace Application.Configurations.Mappers;

public class Mapper : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(UserMapperProfile));
        services.AddAutoMapper(typeof(GroupMapperProfile));
    }
}
