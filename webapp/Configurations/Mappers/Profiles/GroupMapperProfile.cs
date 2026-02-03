using AutoMapper;
using Domain;
using API.Responses;

namespace API.Configurations.Mappers.Profiles;

public class GroupMapperProfile : Profile
{
    public GroupMapperProfile() {
        CreateMap<Group, GroupResponse>();
    }
}
