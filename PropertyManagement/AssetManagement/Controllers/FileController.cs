using AssetManagement.Dto;
using AssetManagement.Models;
using AssetManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Controllers;

[ApiController]
[Authorize]
[Route("api/fileService")]
public class FileController : ControllerBase
{
    private readonly IFileService _fileService;

    public FileController(IFileService fileService)
    {
        _fileService = fileService;
    }

    [HttpPost]
    public async Task<ActionResult<AttachmentFile>> UploadFile([FromForm] FileUploadRequestDto formFile)
    {
        var attachmentFile = await _fileService.AddAttachmentFile(formFile);
        return Ok(attachmentFile);
    }
    
    [HttpGet]
    public async Task<FileResult> DownloadFile(long id)
    {
        var tuple = await _fileService.GetDownloadDetails(id);
        return File(tuple.Item1, "application/octet-stream", tuple.Item2);
    }

    [HttpGet("get")]
    public async Task<ActionResult<List<AttachmentFile>>> GetAll()
    {
        var attachmentFiles = await _fileService.GetAll();
        return Ok(new
        {
            data = attachmentFiles,
            message = "Attachment files found"
        });
    } 
    
    [HttpGet("get/{id}")]
    public async Task<ActionResult<AttachmentFile>> GetById(long id)
    {
        var attachmentFile = await _fileService.GetById(id);
        return Ok(new
        {
            data = attachmentFile,
            message = "Attachment file found"
        });
    }
    
    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> Delete(long id)
    {
        try
        {
            var attachmentFile = _fileService.GetById(id);
        
            if (attachmentFile == null)
            {
                return NotFound(new
                {
                    data = new {},
                    message = "Attachment file not found"
                });
            }
        
            await _fileService.Delete(id);
            return Ok(new
            {
                data = new {},
                message = "Attachment file updated"
            });
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}