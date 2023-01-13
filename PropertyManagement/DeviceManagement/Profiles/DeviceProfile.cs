using AutoMapper;
using DeviceManagement.Constants;
using DeviceManagement.Dtos;
using DeviceManagement.Models;

namespace DeviceManagement.Profiles;

public class DeviceProfile:Profile
{
    public DeviceProfile()
    {
        CreateMap<Device, GrpcDeviceModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

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