using AssetManagement.Dto;
using AssetManagement.Models;
using AssetManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Controllers;

[ApiController]
[Route("api/fileService/filePermission")]
public class FilePermissionController : ControllerBase
{
    private readonly FilePermissionService _filePermissionService;
    private readonly GrpcService _grpcService;
    
    public FilePermissionController(FilePermissionService filePermissionService, GrpcService grpcService)
    {
        _filePermissionService = filePermissionService;
        _grpcService = grpcService;
    }
    
    [HttpPost]
    public async Task<ActionResult<FilePermission>> CreateFilePermission([FromBody] CreateFilePermissionDto filePermission)
    {
        var newFilePermission = new FilePermission()
        {
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            AttachmentFileId = filePermission.AttachmentFileId,
            PermissionId = filePermission.PermissionId,
            UserId = filePermission.UserId
        };
        
        var nfp = await _filePermissionService.Create(newFilePermission);
        return Ok(new
        {
            data = nfp,
            message = "File permission created"
        });
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<FilePermission>> GetFilePermissionById(int id)
    {
        var filePermission = await _filePermissionService.GetById(id);
        
        if (filePermission == null)
        {
            return NotFound(new
            {
                message = "File permission not found"
            });
        }
        
        return Ok(new
        {
            data = filePermission,
            message = "File permission found"
        });
    }
    
    [HttpGet]
    public async Task<ActionResult<List<FilePermission>>> GetAllFilePermissions()
    {
        var filePermissions = await _filePermissionService.GetAll();

        var test = _grpcService.GetUser(1);
        Console.WriteLine("test" + test);
        
        return Ok(new
        {
            data = filePermissions,
            message = "File permissions found"
        });
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteFilePermission(int id)
    {
        var filePermission = await _filePermissionService.GetById(id);
        
        if (filePermission == null)
        {
            return NotFound(new
            {
                message = "File permission not found"
            });
        }
        
        await _filePermissionService.Delete(filePermission);
        return Ok(new
        {
            data = new {},
            message = "File permission deleted"
        });
    }
}