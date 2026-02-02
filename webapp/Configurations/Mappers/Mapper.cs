using API.Configurations.Mappers.Profiles;
using API.Configurations.Mappers;

namespace API.Configurations.Mappers;

public static class Mapper
{
    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(UserMapperProfile));
        services.AddAutoMapper(typeof(GroupMapperProfile));

        return services;
    }
}
