using AuthService.Controllers;
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
            .ForMember(dest=>dest.Status, opt => opt.MapFrom(src => "active"))
            ;

        CreateMap<UpdateProfileDto, User>()
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now))
            //keep old values if new values are null
            .ForAllMembers(cfg=>cfg.Condition((src, dest, srcMember) => srcMember != null))
            ;

        CreateMap<AdminUpdateProfileDto, User>()
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now))

            .ForAllMembers(cfg => cfg.Condition((src, dest, srcMember) => srcMember != null));
    }
}