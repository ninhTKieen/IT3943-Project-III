using AutoMapper;
using DeviceManagement.Data;
using DeviceManagement.Dtos;
using DeviceManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace DeviceManagement.Services;

public class MaintenanceService
{
    private readonly ApplicationDbContext _context;
    public MaintenanceService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
    }
    
    public async Task<MaintenanceHistory> Create(MaintenanceHistory maintenanceHistory )
    {
        await _context.MaintenanceHistories.AddAsync(maintenanceHistory);
        await _context.SaveChangesAsync();
        // return new maintenance history
        return maintenanceHistory;
    }

    public async Task<MaintenanceHistory> GetById(int id)
    {
        //read related data and filtered properties of relation entity
        return await _context.MaintenanceHistories.Where(
            x => x.Id == id).Include(x => x.Device).FirstOrDefaultAsync();
        
    }
    
}
