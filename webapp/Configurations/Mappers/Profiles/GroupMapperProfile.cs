using API.Responses;
using AutoMapper;
using Domain;

namespace API.Configurations.Mappers.Profiles;

public class GroupMapperProfile : Profile
{
    public GroupMapperProfile()
    {
        CreateMap<Group, GroupResponse>();
    }
}
