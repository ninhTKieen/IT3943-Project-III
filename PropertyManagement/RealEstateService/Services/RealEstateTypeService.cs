using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RealEstateService.DbContexts;
using RealEstateService.DTOs;
using RealEstateService.Models;

namespace RealEstateService.Services;

public class RealEstateTypeService
{
    private readonly ApplicationDbContext _context;
    private IMapper _mapper;
    
    public RealEstateTypeService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<List<RealEstateType>> GetRealEstateTypes()
    {
        var realEstateTypes = await _context.RealEstateTypes.ToListAsync();
        return _mapper.Map<List<RealEstateType>>(realEstateTypes);
    }

    public async Task<RealEstateType> GetRealEstateTypeById(int realEstateTypeId)
    {
        var realEstateType = await _context.RealEstateTypes.FirstOrDefaultAsync(x => x.Id == realEstateTypeId);
        return _mapper.Map<RealEstateType>(realEstateType);
    }
    
    public async Task<RealEstateType> CreateRealEstateType(RealEstateTypeDTO realEstateTypeDto)
    {
        var realEstateType = _mapper.Map<RealEstateType>(realEstateTypeDto);
        //iso time
        realEstateType.CreateAt = DateTime.Now;
        realEstateType.UpdatedAt = realEstateType.CreateAt;
        _context.RealEstateTypes.Add(realEstateType);
        await _context.SaveChangesAsync();
        return _mapper.Map<RealEstateType>(realEstateType);
    }
    
    public async Task<RealEstateType> UpdateRealEstateType(int realEstateTypeId, RealEstateTypeDTO realEstateTypeDto)
    {
        var realEstateType = await _context.RealEstateTypes.FirstOrDefaultAsync(x => x.Id == realEstateTypeId);
        if (realEstateType == null)
        {
            return null;
        }

        if (realEstateTypeDto.Name is not null)
        {
            realEstateType.Name = realEstateTypeDto.Name;
        }

        if (realEstateTypeDto.Description is not null)
        {
            realEstateType.Description = realEstateTypeDto.Description;
        }
        realEstateType.UpdatedAt = DateTime.Now;
        await _context.SaveChangesAsync();
        return _mapper.Map<RealEstateType>(realEstateType);
    }
    
    public async Task<bool> DeleteRealEstateType(int realEstateTypeId)
    {
        var realEstateType = await _context.RealEstateTypes.FirstOrDefaultAsync(x => x.Id == realEstateTypeId);
        if (realEstateType == null)
        {
            return false;
        }
        _context.RealEstateTypes.Remove(realEstateType);
        await _context.SaveChangesAsync();
        return true;
    }
}