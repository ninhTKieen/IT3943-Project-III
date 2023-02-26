using System.Runtime.CompilerServices;
using DeviceManagement.Data;
using DeviceManagement.Dtos;
using DeviceManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeviceManagement.Services;

public class DeviceService
{
    private readonly ApplicationDbContext _context;
    public DeviceService(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<Device> GetDeviceByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Device> Create(Device device)
    {
        await _context.Devices.AddAsync(device);
        await _context.SaveChangesAsync();
        return device;
    }

    public async Task<Device> GetById(int id)
    {
        var res = await _context.Devices.FindAsync(id);

        return res;
    }
    
    public async Task<List<Device>> GetAll()
    {
        var res = await _context.Devices.Where(x => true).ToListAsync();
        return res;
    }
    
    public async Task<Device> Update(Device device)
    {
        var test = _context.Devices.Update(device);
        Console.WriteLine("test: " + test);
        await _context.SaveChangesAsync();
        return device;
    }
    
    public async Task Delete(Device device)
    {
        _context.Devices.Remove(device);
        await _context.SaveChangesAsync();
    }
}