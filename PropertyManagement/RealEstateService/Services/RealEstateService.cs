using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateService.DbContexts;
using RealEstateService.DTOs;
using RealEstateService.Models;

namespace RealEstateService.Services;

public class RealEstateService
{
    private readonly ApplicationDbContext _context;
    private IMapper _mapper;
    
    public RealEstateService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<List<RealEstate>> GetRealEstates()
    {
        var realEstates = await _context.RealEstates.ToListAsync();
        return _mapper.Map<List<RealEstate>>(realEstates);
    }
    
    public async Task<RealEstate> CreateRealEstate(RealEstateDTO realEstateDto)
    {
        var realEstate = _mapper.Map<RealEstate>(realEstateDto);
        _context.RealEstates.Add(realEstate);
        realEstate.CreateAt = DateTime.Now;
        realEstate.UpdatedAt = realEstate.CreateAt;
        await _context.SaveChangesAsync();
        return _mapper.Map<RealEstate>(realEstate);;
    }

    public async Task<RealEstate> GetRealEstateById(int realEstateId)
    {
        var realEstate = await _context.RealEstates.FirstOrDefaultAsync(x => x.Id == realEstateId);
        return _mapper.Map<RealEstate>(realEstate);
    }
    
    public async Task<RealEstate> UpdateRealEstate(int realEstateId, RealEstateDTO realEstateDto)
    {
        var realEstate = await _context.RealEstates.FirstOrDefaultAsync(x => x.Id == realEstateId);
        if (realEstate == null)
        {
            return null;
        }
        
        realEstate.Status = realEstateDto.Status ?? realEstate.Status;
        realEstate.Owner= realEstateDto.Owner ?? realEstate.Owner;
        realEstate.Latitude = realEstateDto.Latitude ?? realEstate.Latitude;
        realEstate.Longitude = realEstateDto.Longitude ?? realEstate.Longitude;
        realEstate.Location = realEstateDto.Location ?? realEstate.Location;
        realEstate.Description = realEstateDto.Description ?? realEstate.Description;
        realEstate.ImageUrl = realEstateDto.ImageUrl ?? realEstate.ImageUrl;
        realEstate.Area = realEstateDto.Area ?? realEstate.Area;
        realEstate.CurrentPrice = realEstateDto.CurrentPrice ?? realEstate.CurrentPrice;
        realEstate.Tax = realEstateDto.Tax ?? realEstate.Tax;
        
        realEstate.UpdatedAt = DateTime.Now;
        await _context.SaveChangesAsync();
        return _mapper.Map<RealEstate>(realEstate);
    }
    
    public async Task<bool> DeleteRealEstate(int realEstateId)
    {
        var realEstate = await _context.RealEstates.FirstOrDefaultAsync(x => x.Id == realEstateId);
        if (realEstate == null)
        {
            return false;
        }
        
        _context.RealEstates.Remove(realEstate);
        await _context.SaveChangesAsync();
        return true;
    }
}