using DeviceManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeviceManagement.Controllers;

[ApiController]
[Route("api/device")]
public class DeviceController : ControllerBase
{
    private readonly DeviceService _deviceService;
    public DeviceController(DeviceService deviceService)
    {
        _deviceService = deviceService;
    }
    // GET
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        await _deviceService.Create();
        return Ok("Hello World");
    }
}