using API.Configurations.Mappers;
using API.Configurations.Mappers.Profiles;

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
