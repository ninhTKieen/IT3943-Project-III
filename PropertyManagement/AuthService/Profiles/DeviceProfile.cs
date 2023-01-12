using AuthService.Models;
using AutoMapper;

namespace AuthService.Profiles;

public class DeviceProfile: Profile
{
    public DeviceProfile()
    {
        CreateMap<GrpcDeviceModel, Device>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
    }
}