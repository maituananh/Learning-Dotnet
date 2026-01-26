using Application.Commands.User;
using AutoMapper;
using API.Requests;

namespace API.Configurations.Mappers.Profiles
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile() {
            CreateMap<UserCreateRequest, CreateUserCommand>();
        }
    }
}
