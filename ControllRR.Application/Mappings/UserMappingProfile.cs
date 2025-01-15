using AutoMapper;
using ControllRR.Application.DTOs;
using ControllRR.Domain.Entities;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}