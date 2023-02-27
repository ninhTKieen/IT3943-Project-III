using AutoMapper;
using DeviceManagement.Dtos;
using DeviceManagement.Models;
using DeviceManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeviceManagement.Controllers;

[ApiController]
[Route("api/maintenanceHistory")]
public class MaintenanceController : ControllerBase
{
    private readonly MaintenanceService _maintenanceService;
    private readonly DeviceService _deviceService;
    private readonly IMapper _mapper;
    public MaintenanceController(MaintenanceService maintenanceService, DeviceService deviceService, IMapper mapper)
    {
        _maintenanceService = maintenanceService;
        _deviceService = deviceService;
        _mapper = mapper;
    }
    
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] MaintenanceCreateDto maintenanceCreateDto)
    {
        try
        {
            var device = await _deviceService.GetById(maintenanceCreateDto.DeviceId);
            
            if (device == null)
            {
                return NotFound(new
                {
                    data = new { },
                    message = "Not found device"
                });
            }
            
            var maintenance = _mapper.Map<MaintenanceHistory>(maintenanceCreateDto);
            var newMaintenance = await _maintenanceService.Create(maintenance);
            return Ok(new {data=newMaintenance, message = "Device created successfully"});
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<MaintenanceHistory>>> GetAll()
    {
        try
        {
            var result = await _maintenanceService.GetAll();
            return Ok(new {data=result, message = "Device get successfully"});  
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MaintenanceHistory>> GetById(int id)
    {
        try
        {
            var result = await _maintenanceService.GetById(id);
            if (result == null)
            {
                return NotFound(new
                {
                    data = new { },
                    message = "Not found maintenance history"
                });
            }
            return Ok(new {data=result, message = "Device get successfully"});
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MaintenanceHistory>> Update(int id, [FromBody] MaintenanceUpdateDto maintenanceUpdateDto)
    {
        try
        {
            var result = await _maintenanceService.GetById(id);
            if (result == null)
            {
                return NotFound(new
                {
                    data = new { },
                    message = "Not found maintenance history"
                });
            }
            _mapper.Map(maintenanceUpdateDto, result);
            
            var res = await _maintenanceService.Update(result);
            return Ok(new
            {
                data = res,
                message = "Maintenance history updated successfully"
            });
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _maintenanceService.GetById(id);
        if (result == null)
        {
            return NotFound(new
            {
                data = new { },
                message = "Not found maintenance history"
            });
        }
        
        await _maintenanceService.Delete(result);
        return Ok(new
        {
            data = new { },
            message = "Maintenance history deleted successfully"
        });
    }
}