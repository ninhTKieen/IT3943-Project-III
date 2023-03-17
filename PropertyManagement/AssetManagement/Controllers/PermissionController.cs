using AssetManagement.Dto;
using AssetManagement.Models;
using AssetManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Controllers;

[ApiController]
[Route("api/fileService/permission")]
public class PermissionController : ControllerBase
{
    private PermissionService _permissionService;
    
    public PermissionController(PermissionService permissionService)
    {
        _permissionService = permissionService;
    }
    
    [HttpPost]
    public async Task<ActionResult<Permission>> CreatePermission([FromBody] CreatePermissionDto permission)
    {
        var newPermission = await _permissionService.CreatePermission(permission);
        return Ok(new
        {
            data = newPermission,
            message = "Permission created"
        });
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdatePermission([FromBody] UpdatePermissionDto permission, int id)
    {
        var oldPermission = await _permissionService.GetPermissionById(id);
        
        if (permission == null)
        {
            return NotFound(new
            {
                message = "Permission not found"
            });
        }
        
        oldPermission.Action = permission.Action;
        oldPermission.UpdatedAt = DateTime.Now.ToString();
        
        await _permissionService.UpdatePermission(oldPermission);
        return Ok(new
        {
            data = new {},
            message = "Permission updated"
        });
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePermission(int id)
    {
        var permission = await _permissionService.GetPermissionById(id);
        
        if (permission == null)
        {
            return NotFound(new
            {
                message = "Permission not found"
            });
        }
        
        await _permissionService.DeletePermission(permission);
        return Ok(new
        {
            data = new {},
            message = "Permission deleted"
        });
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Permission>> GetPermissionById(int id)
    {
        var permission = await _permissionService.GetPermissionById(id);
        
        if (permission == null)
        {
            return NotFound(new
            {
                message = "Permission not found"
            });
        }
        
        return Ok(new
        {
            data = permission,
            message = "Permission found"
        });
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Permission>>> GetAllPermissions()
    {
        var permissions = await _permissionService.GetAllPermissions();
        
        if (permissions == null)
        {
            return NotFound(new
            {
                message = "Permissions not found"
            });
        }
        
        return Ok(new
        {
            data = permissions,
            message = "Permissions found"
        });
    }
}