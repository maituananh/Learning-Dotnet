using API.Responses;
using AutoMapper;

namespace API.Configurations.Mappers.Profiles;

public class GroupMapperProfile : Profile
{
    public GroupMapperProfile()
    {
        CreateMap<Group, GroupResponse>();
    }
}
