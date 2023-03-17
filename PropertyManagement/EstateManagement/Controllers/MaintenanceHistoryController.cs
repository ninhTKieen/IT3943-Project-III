using AutoMapper;
using EstateManagement.Dtos;
using EstateManagement.Models;
using EstateManagement.Services;
using EstateManagement.Constants;
using Microsoft.AspNetCore.Mvc;

namespace EstateManagement.Controllers;

[ApiController]
[Route("api/MaintenanceHistory")]
public class MaintenanceHistoryController: Controller
{
    private readonly MaintenanceHistoryServices _maintenanceHistoryServices;
    private readonly IMapper _mapper;
    
    public MaintenanceHistoryController(MaintenanceHistoryServices maintenanceHistoryServices, IMapper mapper)
    {
        _maintenanceHistoryServices = maintenanceHistoryServices;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var maintenanceHistories = await _maintenanceHistoryServices.GetMaintenanceHistories();
        return Ok(new {data = maintenanceHistories, message = "Maintenance histories found"});
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var maintenanceHistory = await _maintenanceHistoryServices.GetMaintenanceHistory(id);
        if (maintenanceHistory == null)
        {
            return NotFound(new {message = "Maintenance history not found", data = new {}});
        }
        //check type is not in enum
        return Ok(new {data = maintenanceHistory, message = "Maintenance history found"});
    }
    
    [HttpPost]
    public async Task<IActionResult> AddMaintenanceHistory([FromBody] MaintenanceHistoryCreateDto maintenanceHistoryCreate)
    {
        var realEstate = await _maintenanceHistoryServices.GetRealEstate(maintenanceHistoryCreate.RealEstateId);
        if (realEstate == null)
        {
            return BadRequest(new {message = "Real estate not found"});
        }
        if (!Enum.IsDefined(typeof(MaintenanceType), maintenanceHistoryCreate.Type))
        {
            return BadRequest(new {message = "Type not available", data = new {}});
        }
        var maintenanceHistory = _mapper.Map<MaintenanceHistory>(maintenanceHistoryCreate);
        maintenanceHistory.RealEstate = realEstate;
        var maintenanceHistoryCreated = await _maintenanceHistoryServices.AddMaintenanceHistory(maintenanceHistory);
        return Ok(new {data = maintenanceHistoryCreated, message = "Maintenance history created"});
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMaintenanceHistory(int id, MaintenanceHistoryUpdateDto maintenanceHistoryDto)
    {
        var maintenanceHistory = await _maintenanceHistoryServices.GetMaintenanceHistory(id);

        if (maintenanceHistory == null)
        {
            return NotFound();
        }
        // Check if type is not in enum
        if (maintenanceHistoryDto.Type != null)
        {
            if (!Enum.IsDefined(typeof(MaintenanceType), maintenanceHistoryDto.Type))
            {
                return BadRequest(new {message = "Type not available", data = new {}});
            }
        }
        maintenanceHistoryDto.Type ??= maintenanceHistory.Type;
        maintenanceHistoryDto.RealEstateId ??= maintenanceHistory.RealEstateId;
        maintenanceHistoryDto.Expenses ??= maintenanceHistory.Expenses;
        
        // Map properties from maintenanceHistoryDto to maintenanceHistory object
        _mapper.Map<MaintenanceHistoryUpdateDto, MaintenanceHistory>(maintenanceHistoryDto, maintenanceHistory);
        // Check if RealEstateId exists in RealEstate table
        if(maintenanceHistoryDto.RealEstateId != null)
        {
            var realEstate = await _maintenanceHistoryServices.GetRealEstate(maintenanceHistoryDto.RealEstateId.Value);
            if (realEstate == null)
            {
                return BadRequest(new {message = "Real estate not found"});
            }
            maintenanceHistory.RealEstate = realEstate;
        }
        //update
        var maintenanceHistoryUpdated = await _maintenanceHistoryServices.UpdateMaintenanceHistory(id, maintenanceHistory);
        return Ok(new {data = maintenanceHistoryUpdated, message = "Maintenance history updated"});
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMaintenanceHistory(int id)
    {
        var maintenanceHistory = await _maintenanceHistoryServices.GetMaintenanceHistory(id);
        if (maintenanceHistory == null)
        {
            return NotFound();
        }
        await _maintenanceHistoryServices.DeleteMaintenanceHistory(id);
        return Ok(new {message = "Maintenance history deleted"});
    }
}