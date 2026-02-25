using Application.Responses;
using AutoMapper;
using Domain;

namespace Application.Configurations.Mappers.Profiles;

public class GroupMapperProfile : Profile
{
    public GroupMapperProfile()
    {
        CreateMap<Group, GroupResponse>();
    }
}
