using API.Requests;
using API.Responses;
using Application.Commands;
using AutoMapper;
using Domain;

namespace API.Configurations.Mappers.Profiles
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<UserCreateRequest, CreateUserCommand>();
            CreateMap<User, UserResponse>();
            CreateMap<GroupUser, GroupUserResponse>();
        }
    }
}
