using AutoMapper;
using DeviceManagement.Constants;
using DeviceManagement.Dtos;
using DeviceManagement.Models;

namespace DeviceManagement.Profiles;

public class MaintenanceProfile: Profile
{
    public MaintenanceProfile()
    {
        CreateMap<MaintenanceCreateDto, MaintenanceHistory>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now))
            //status = inProgress if status is null
            .ForMember(dest => dest.Status, opt => opt.NullSubstitute(MaintenanceStatus.InProgress));
        
        CreateMap<MaintenanceUpdateDto, MaintenanceHistory>()
            .ForMember(dest=>dest.UpdatedAt, opt => opt.MapFrom(src=>DateTime.Now))
            .ForAllMembers(opt=>opt.Condition((src, dest, srcMember)=> srcMember != null));
    }
}