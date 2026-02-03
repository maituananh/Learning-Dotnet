using Application.Commands.User;
using AutoMapper;
using API.Requests;
using Domain;
using API.Responses;

namespace API.Configurations.Mappers.Profiles
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile() {
            CreateMap<UserCreateRequest, CreateUserCommand>();
            CreateMap<User, UserResponse>();
        }
    }
}
