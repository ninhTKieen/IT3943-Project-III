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

    public async Task<Response<DeviceResponse>> GetById(int id)
    {
        var res = await _context.Devices.Select(c => new DeviceResponse()
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description,
            Brand = c.Brand,
            Cost = c.Cost,
            ImageUrl = c.ImageUrl,
            InstallationDate = c.InstallationDate,
            LastServiceDate = c.LastServiceDate,
            Latitude = c.Latitude,
            Longitude = c.Longitude,
            Manager = c.Manager,
            Origin = c.Origin,
            Owner = c.Owner,
            Position = c.Position,
            PurchaseDate = c.PurchaseDate,
            Sku = c.Sku,
            Status = c.Status,
            Type = c.Type,
            WarrantyDate = c.WarrantyDate,
            CreatedAt = c.CreatedAt,
            UpdatedAt = c.UpdatedAt,
            MaintenanceHistories = c.MaintenanceHistories.Select(e => new MaintenanceResponse
            {
                Id = e.Id,
                Name = e.Name
            })
        }).Where(c => c.Id == id).ToListAsync();

        return new Response<DeviceResponse>(res);
    }
    
    public async Task<List<Device>> GetAll()
    {
        //using linq syntax
        var device = await (from s in _context.Devices
                where s.Id == 10
                select s
            ).ToListAsync();

        return device;
        // return await _context.Devices.ToListAsync();
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