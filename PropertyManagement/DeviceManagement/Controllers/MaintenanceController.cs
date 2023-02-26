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
    private readonly IMapper _mapper;
    public MaintenanceController(MaintenanceService maintenanceService, IMapper mapper)
    {
        _maintenanceService = maintenanceService;
        _mapper = mapper;
    }
    
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] MaintenanceCreateDto maintenanceCreateDto)
    {
        try
        {
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

    [HttpGet("{id}")]
    public async Task<ActionResult<MaintenanceHistory>> GetById(int id)
    {
        try
        {
            var result = await _maintenanceService.GetById(id);
            return Ok(new {data=result, message = "Device get successfully"});
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}