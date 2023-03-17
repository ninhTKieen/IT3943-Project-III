using AutoMapper;
using EstateManagement.DbContexts;
using EstateManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EstateManagement.Services;

public class MaintenanceHistoryServices
{
    private readonly ApplicationDbContext _dbContext;
    private IMapper _mapper;
    
    public MaintenanceHistoryServices(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    //get all maintenance history
    public async Task<List<MaintenanceHistory>> GetMaintenanceHistories()
    {
        var maintenanceHistories = await _dbContext.MaintenanceHistories.Include(m => m.RealEstate).ToListAsync();;
        return _mapper.Map<List<MaintenanceHistory>>(maintenanceHistories);
    }
    
    // add new maintenance history
    public async Task<MaintenanceHistory> AddMaintenanceHistory(MaintenanceHistory maintenanceHistory)
    {
        await _dbContext.MaintenanceHistories.AddAsync(maintenanceHistory);
        await _dbContext.SaveChangesAsync();
        return maintenanceHistory;
    }
    
    //get maintenance history by id
    public async Task<MaintenanceHistory> GetMaintenanceHistory(int id)
    {
        var maintenanceHistory = await _dbContext.MaintenanceHistories
            .Include(m => m.RealEstate)
            .FirstOrDefaultAsync(m => m.Id == id);
        return _mapper.Map<MaintenanceHistory>(maintenanceHistory);
    }
    
    //find real estate by id
    public async Task<RealEstate> GetRealEstate(int id)
    {
        var realEstate = await _dbContext.RealEstates.FindAsync(id);
        return realEstate;
    }
    
    //update maintenance history
    public async Task<bool> UpdateMaintenanceHistory(int id, MaintenanceHistory maintenanceHistory)
    {
        var maintenanceHistoryToUpdate = await _dbContext.MaintenanceHistories.FindAsync(id);
        if (maintenanceHistoryToUpdate == null)
        {
            return false;
        }

        var realEstate = _dbContext.RealEstates.FirstOrDefault(r => r.Id == maintenanceHistory.RealEstateId);
        if (realEstate == null)
        {
            throw new Exception("RealEstate record does not exist");
        }

        maintenanceHistoryToUpdate.Name = maintenanceHistory.Name;
        maintenanceHistoryToUpdate.Description = maintenanceHistory.Description;
        maintenanceHistoryToUpdate.Expenses = maintenanceHistory.Expenses;
        maintenanceHistoryToUpdate.StartDate = maintenanceHistory.StartDate;
        maintenanceHistoryToUpdate.EndDate = maintenanceHistory.EndDate;
        maintenanceHistoryToUpdate.Type = maintenanceHistory.Type;
        maintenanceHistoryToUpdate.Creater = maintenanceHistory.Creater;
        maintenanceHistoryToUpdate.CreatedAt = maintenanceHistory.CreatedAt;
        maintenanceHistoryToUpdate.UpdatedAt = maintenanceHistory.UpdatedAt;
        // maintenanceHistoryToUpdate.RealEstate = maintenanceHistory.RealEstate;
        maintenanceHistoryToUpdate.RealEstateId = maintenanceHistory.RealEstateId;
        _dbContext.MaintenanceHistories.Update(maintenanceHistoryToUpdate);
        await _dbContext.SaveChangesAsync();
        return true;
    }
    
    //delete maintenance history
    public async Task<bool> DeleteMaintenanceHistory(int id)
    {
        var maintenanceHistory = await _dbContext.MaintenanceHistories.FindAsync(id);
        if (maintenanceHistory == null)
        {
            return false;
        }
        _dbContext.MaintenanceHistories.Remove(maintenanceHistory);
        await _dbContext.SaveChangesAsync();
        return true;
    }
    
}