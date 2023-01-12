using System.Runtime.CompilerServices;
using DeviceManagement.Data;
using DeviceManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeviceManagement.Services;

public class DeviceService
{
    // private  readonly  DbSet<Device> _devices;
    
    private readonly ApplicationDbContext _context;
    public DeviceService(ApplicationDbContext context)
    {
        // _devices = context.Devices
        _context = context;
    }

    public Task<Device> GetDeviceByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task Create()
    {
        var device = new Device()
        {
            Name = "test"
        };
        await _context.Devices.AddAsync(device);
        await _context.SaveChangesAsync();
        // throw new NotImplementedException();
    }
}