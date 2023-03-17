using AutoMapper;
using EstateManagement.DbContexts;
using EstateManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace EstateManagement.Services;

public class RealEstateServices
{
    private readonly ApplicationDbContext _dbContext;
    private IMapper _mapper;

    public RealEstateServices(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<List<RealEstate>> GetRealEstates()
    {
        var realEstates = await _dbContext.RealEstates.Include(r => r.type)
            .Include(r => r.MaintenanceHistories)
            .ToListAsync();;
        return _mapper.Map<List<RealEstate>>(realEstates);
    }
    
    public async Task<RealEstate> GetRealEstate(int id)
    {
        var realEstate = await _dbContext.RealEstates
            .Include(r => r.type)
            .Include(r => r.MaintenanceHistories)
            .FirstOrDefaultAsync(r => r.Id == id);
        return _mapper.Map<RealEstate>(realEstate);
    }
    
    //add new real estate
    public async Task<RealEstate> AddRealEstate(RealEstate realEstate)
    {
        await _dbContext.RealEstates.AddAsync(realEstate);
        await _dbContext.SaveChangesAsync();
        return realEstate;
    }
    
    //find real estate type by id
    public async Task<RealEstateType> GetRealEstateType(int id)
    {
        var realEstateType = await _dbContext.RealEstateTypes.FindAsync(id);
        return _mapper.Map<RealEstateType>(realEstateType);
    }
    
    //update real estate
    public async Task<bool> UpdateRealEstate(int id, RealEstate realEstate)
    {
        var realEstateToUpdate = await _dbContext.RealEstates.FindAsync(id);
        if (realEstateToUpdate == null)
        {
            return false;
        }
        realEstateToUpdate.Status = realEstate.Status;
        realEstateToUpdate.CreatedAt = realEstate.CreatedAt;
        realEstateToUpdate.Latitude = realEstate.Latitude;
        realEstateToUpdate.Longitude = realEstate.Longitude;
        realEstateToUpdate.Location = realEstate.Location;
        realEstateToUpdate.Description = realEstate.Description;
        realEstateToUpdate.Area = realEstate.Area;
        realEstateToUpdate.ImageUrl = realEstate.ImageUrl;
        realEstateToUpdate.CurrentPrice = realEstate.CurrentPrice;
        realEstateToUpdate.Tax = realEstate.Tax;
        realEstateToUpdate.type = realEstate.type;
        await _dbContext.SaveChangesAsync();
        return true;
    }

    //delete real estate
    public async Task<bool> DeleteRealEstate(int id)
    {
        var realEstate = await _dbContext.RealEstates.FindAsync(id);
        if (realEstate == null)
        {
            return false;
        }
        _dbContext.RealEstates.Remove(realEstate);
        await _dbContext.SaveChangesAsync();
        return true;
    }
    
    
}