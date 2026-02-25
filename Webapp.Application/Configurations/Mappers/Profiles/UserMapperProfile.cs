using Application.Commands;
using Application.Requests;
using Application.Responses;
using AutoMapper;
using Domain;
using Domain.domain;

namespace Application.Configurations.Mappers.Profiles;

public class UserMapperProfile : Profile
{
    public UserMapperProfile()
    {
        CreateMap<UserCreateRequest, CreateUserCommand>();
        CreateMap<User, UserResponse>();
        CreateMap<GroupUser, GroupUserResponse>();
        CreateMap<AuthRequest, AuthenticationCommand>();
        CreateMap<Token, AuthResponse>();
    }
}
