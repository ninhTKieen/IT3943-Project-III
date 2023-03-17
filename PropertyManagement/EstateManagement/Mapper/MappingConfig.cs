using AutoMapper;
using EstateManagement.Models;
using EstateManagement.Dtos;
namespace EstateManagement.Mapper;

public class MappingConfig
{
    public static MapperConfiguration RegisterMap()
    {
        return new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<RealEstateType, RealEstateTypeCreateDto>();
            cfg.CreateMap<RealEstateTypeCreateDto, RealEstateType>()
                .ForMember(dest => dest.CreateAt, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now));

            cfg.CreateMap<RealEstateCreateDto, RealEstate>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now));
            cfg.CreateMap<RealEstateUpdateDto, RealEstate>()
                .ForMember(opt => opt.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now))
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            cfg.CreateMap<MaintenanceHistory, MaintenanceHistoryWithoutRealEstate>();
            cfg.CreateMap<MaintenanceHistoryCreateDto, MaintenanceHistory>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now));
            cfg.CreateMap<MaintenanceHistoryUpdateDto, MaintenanceHistory>()
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now))
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            cfg.CreateMap<MaintenanceHistoryUpdateDto, MaintenanceHistory>()
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now))
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

        });
    }
}