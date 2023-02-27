using AutoMapper;
using RealEstateService.DTOs;
using RealEstateService.Models;

namespace RealEstateService.Mapper;

public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        return new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<RealEstateType, RealEstateTypeDTO>();
            cfg.CreateMap<RealEstateTypeDTO, RealEstateType>();

            cfg.CreateMap<RealEstate, RealEstateDTO>();
            cfg.CreateMap<RealEstateDTO, RealEstate>();
        });
    }
}