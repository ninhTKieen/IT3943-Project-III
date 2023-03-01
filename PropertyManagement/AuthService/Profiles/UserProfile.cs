using AuthService.Dto;
using AuthService.Models;
using AutoMapper;

namespace AuthService.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<RegisterDto, User>()
            .ForMember(dest=> dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest=>dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => "user"))
            ;
    }
}