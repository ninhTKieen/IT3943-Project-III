using AssetManagement.Models;
using AssetManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class FileController : ControllerBase
{
    private readonly IFileService _fileService;

    public FileController(IFileService fileService)
    {
        _fileService = fileService;
    }

    [HttpPost]
    public async Task<ActionResult<AttachmentFile>> UploadFile(IFormFile iFormFile)
    {
        var attachmentFile = await _fileService.AddAttachmentFile(iFormFile);
        return Ok(attachmentFile);
    }
    
    [HttpGet]
    public async Task<FileResult> DownloadFile(long id)
    {
        var tuple = await _fileService.GetDownloadDetails(id);
        return File(tuple.Item1, "application/octet-stream", tuple.Item2);
    }
}