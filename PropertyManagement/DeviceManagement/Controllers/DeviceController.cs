using AutoMapper;
using DeviceManagement.Dtos;
using DeviceManagement.Models;
using DeviceManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeviceManagement.Controllers;

[ApiController]
[Route("api/device")]
public class DeviceController : ControllerBase
{
    private readonly DeviceService _deviceService;
    private readonly IMapper _mapper;
    public DeviceController(DeviceService deviceService, IMapper mapper)
    {
        _deviceService = deviceService;
        _mapper = mapper;
    }
    // GET
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok("Hello World");
    }
    
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] DeviceCreateDto deviceCreateDto)
    {
        try
        {
            var device = _mapper.Map<Device>(deviceCreateDto);
            var newDevice = await _deviceService.Create(device);
            return Ok(new {data=newDevice, message = "Device created successfully"});
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}