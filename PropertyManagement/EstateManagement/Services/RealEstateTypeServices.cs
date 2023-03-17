using EstateManagement.DbContexts;
using EstateManagement.Dtos;
using EstateManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EstateManagement.Services;

public class RealEstateTypeServices
{
    private readonly ApplicationDbContext _dbContext;

    public RealEstateTypeServices(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<RealEstateType>> GetAll()
    {
        var realEstateTypes = await _dbContext.RealEstateTypes.ToListAsync();
        return realEstateTypes;
    }
    
    //get by id
    public async Task<RealEstateType> Get(int id)
    {
        var realEstateType = await _dbContext.RealEstateTypes.FindAsync(id);
        return realEstateType;
    }
    
    // add new real estate type
    public async Task<RealEstateType> Create(RealEstateType realEstateType)
    {
        await _dbContext.RealEstateTypes.AddAsync(realEstateType);
        await _dbContext.SaveChangesAsync();
        return realEstateType;
    }
    
    //update real estate type
    public async Task<RealEstateType> Update(RealEstateType realEstateType)
    {
        _dbContext.RealEstateTypes.Update(realEstateType);
        await _dbContext.SaveChangesAsync();
        return realEstateType;
    }
    
    //delete real estate type
    public async Task<RealEstateType> Delete(int id)
    {
        var realEstateType = await _dbContext.RealEstateTypes.FindAsync(id);
        _dbContext.RealEstateTypes.Remove(realEstateType);
        await _dbContext.SaveChangesAsync();
        return realEstateType;
    }
}