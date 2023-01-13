using AutoMapper;
using DeviceManagement.Constants;
using DeviceManagement.Dtos;
using DeviceManagement.Models;
using DeviceManagement.Protos;

namespace DeviceManagement.Profiles;

public class DeviceProfile:Profile
{
    public DeviceProfile()
    {
        CreateMap<Device, PDevice>().
            ForMember(dest=>dest.Id, opt=>opt.MapFrom(src=>src.Id)).
            ForMember(dest=>dest.Name, opt=>opt.MapFrom(src=>src.Name)).
            ForMember(dest=>dest.Status, opt=>opt.MapFrom(src=>src.Status)).
            ForMember(dest=>dest.Type, opt=>opt.MapFrom(src=>src.Type)).
            ForMember(dest=>dest.CreatedAt, opt=>opt.MapFrom(src=>src.CreatedAt.Year)).
            ForMember(dest=>dest.UpdatedAt, opt=>opt.MapFrom(src=>src.UpdatedAt.Year)).
            ForMember(dest=>dest.Brand, opt=>opt.MapFrom(src=>src.Brand)).

            ForMember(dest=>dest.PurchaseDate, opt=>opt.MapFrom(src=>src.PurchaseDate.Year)).
            ForMember(dest=>dest.WarrantyDate, opt=>opt.MapFrom(src=>src.InstallationDate.Year)).
            ForMember(dest=>dest.LastServiceDate, opt=>opt.MapFrom(src=>src.InstallationDate.Year)).
            ForMember(dest=>dest.InstallationDate, opt=>opt.MapFrom(src=>src.InstallationDate.Year))

            .ReverseMap();

        CreateMap<DeviceCreateDto, Device>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => DeviceStatus.Working));
        
        CreateMap<DeviceUpdateDto, Device>()
            .ForMember(dest=>dest.UpdatedAt, opt=> opt.MapFrom(src=>DateTime.Now))
            .ForAllMembers(opt=>opt.Condition((src, dest, srcMember)=> srcMember != null))
            ;
    }
}