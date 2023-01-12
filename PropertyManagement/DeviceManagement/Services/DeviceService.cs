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
}