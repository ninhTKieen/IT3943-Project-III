using AssetManagement.Data;
using AssetManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Services;

public class FilePermissionService
{
    private readonly ApplicationDbContext _context;
    
    public FilePermissionService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<FilePermission> Create(FilePermission filePermission)
    {
        await _context.FilePermissions.AddAsync(filePermission);
        await _context.SaveChangesAsync();

        return filePermission;
    }
    
    public async Task Update(FilePermission filePermission)
    {
        _context.Update(filePermission);

        await _context.SaveChangesAsync();
    }
    
    public async Task Delete(FilePermission filePermission)
    {
        _context.Remove(filePermission);

        await _context.SaveChangesAsync();
    }
    
    public async Task<FilePermission> GetById(int id)
    {
        var filePermission = await _context.FilePermissions.FindAsync(id);

        return filePermission;
    }
    
    public async Task<List<FilePermission>> GetAll()
    {
        var filePermissions = await _context.FilePermissions.ToListAsync();

        return filePermissions;
    }

}