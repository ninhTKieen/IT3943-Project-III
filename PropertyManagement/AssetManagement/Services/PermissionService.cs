using AssetManagement.Data;
using AssetManagement.Dto;
using AssetManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Services;

public class PermissionService
{
    private readonly ApplicationDbContext _context;
    
    public PermissionService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Permission> CreatePermission(CreatePermissionDto permission)
    {
        var newPermission = new Permission
        {
            Action = permission.Action,
            CreatedAt = DateTime.Now.ToString(),
            UpdatedAt = DateTime.Now.ToString()
        };
        
        await _context.Permissions.AddAsync(newPermission);
        await _context.SaveChangesAsync();

        return newPermission;
    }
    
    public async Task UpdatePermission(Permission permission)
    {
        _context.Update(permission);

        await _context.SaveChangesAsync();
    }
    
    public async Task DeletePermission(Permission permission)
    {
        _context.Remove(permission);

        await _context.SaveChangesAsync();
    }
    
    public async Task<Permission> GetPermissionById(int id)
    {
        var permission = await _context.Permissions.Include(c=>c.FilePermissions).Where(x => x.Id == id).SingleOrDefaultAsync();

        return permission;
    }
    
    public async Task<List<Permission>> GetAllPermissions()
    {
        var permissions = await _context.Permissions.ToListAsync();

        return permissions;
    }
    
    
}