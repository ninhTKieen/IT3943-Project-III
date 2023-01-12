using AutoMapper;
using DeviceManagement.Models;

namespace DeviceManagement.Profiles;

public class DeviceProfile:Profile
{
    public DeviceProfile()
    {
        CreateMap<Device, GrpcDeviceModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
    }
}