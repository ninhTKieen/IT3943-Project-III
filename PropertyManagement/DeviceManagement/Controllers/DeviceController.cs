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

    [HttpGet("{id}")]
    public async Task<ActionResult<Device>> Get(int id)
    {
        try
        {
            var device = await _deviceService.GetById(id);
            if (device == null)
            {
                return NotFound(new {message = "Device not found", data = new {}});
            }
            return Ok(new {data = device, message = "Device found"});
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet]
    public async Task<ActionResult<Device>> GetAll()
    {
        try
        {
            var devices = await _deviceService.GetAll();
            if (devices == null)
            {
                return NotFound(new {message = "No device found", data = new {}});
            }
            return Ok(new {data = devices, message = "Devices found"});
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Device>> Update(int id, [FromBody] DeviceUpdateDto deviceUpdateDto)
    {
        try
        {
            var device = await _deviceService.GetById(id);
            if (device == null)
            {
                return NotFound(new {message = "Device not found", data = new {}});
            }
            _mapper.Map(deviceUpdateDto, device);
            await _deviceService.Update(device);
            return Ok(new {data = device, message = "Device updated successfully"});
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpDelete("id")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            var device = await _deviceService.GetById(id);
            if (device == null)
            {
                return NotFound(new {message = "Device not found", data = new {}});
            }
            
            await _deviceService.Delete(device);
            return Ok(new {data = new {}, message = "Device deleted successfully"});
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}