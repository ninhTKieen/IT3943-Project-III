using AutoMapper;
using EstateManagement.Services;
using EstateManagement.Dtos;
using EstateManagement.Models;
using EstateManagement.Constants;
using Microsoft.AspNetCore.Mvc;
namespace EstateManagement.Controllers;

[ApiController]
[Route("api/RealEstate")]
public class RealEstateController: Controller
{
    private readonly RealEstateServices _realEstateServices;
    private readonly IMapper _mapper;
    
    public RealEstateController(RealEstateServices _realEstateServices, IMapper _mapper)
    {
        this._realEstateServices = _realEstateServices;
        this._mapper = _mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var realEstates = await _realEstateServices.GetRealEstates();
        return Ok(new {data = realEstates, message = "Real estates found"});
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var realEstate = await _realEstateServices.GetRealEstate(id);
        if (realEstate == null)
        {
            return NotFound(new {message = "Real estate not found", data = new {}});
        }
        return Ok(new {data = realEstate, message = "Real estate found"});
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] RealEstateCreateDto realEstateCreateDto)
    {
        try
        {
            //find real estate type by id
            var realEstateType = await _realEstateServices.GetRealEstateType(realEstateCreateDto.TypeId);
            if (realEstateType == null)
            {
                return NotFound(new {message = "Real estate type not found", data = new {}});
            }
            //check status not in enum
            if (!Enum.IsDefined(typeof(EstateStatus), realEstateCreateDto.Status))
            {
                return BadRequest(new {message = "Status not available", data = new {}});
            }
            var realEstate = _mapper.Map<RealEstate>(realEstateCreateDto);
            realEstate.type = realEstateType;
            var newRealEstate = await _realEstateServices.AddRealEstate(realEstate);
            return Ok(new {data=newRealEstate, message = "Real estate created successfully"});
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] RealEstateUpdateDto realEstateUpdateDto)
    {
        var realEstate = await _realEstateServices.GetRealEstate(id);
        if (realEstate == null)
        {
            return NotFound(new {message = "Real estate not found", data = new {}});
        }
        // check all number type is null
        realEstateUpdateDto.Area ??= realEstate.Area;
        realEstateUpdateDto.TypeId ??= realEstate.type.Id;
        realEstateUpdateDto.Latitude ??= realEstate.Latitude;
        realEstateUpdateDto.Longitude ??= realEstate.Longitude;
        realEstateUpdateDto.Status ??= realEstate.Status;
        realEstateUpdateDto.CurrentPrice ??= realEstate.CurrentPrice;
        realEstateUpdateDto.Tax ??= realEstate.Tax;
        
        _mapper.Map(realEstateUpdateDto, realEstate);
        //check status not in enum
        if (realEstateUpdateDto.Status != null && !Enum.IsDefined(typeof(EstateStatus), realEstateUpdateDto.Status))
        {
            return BadRequest(new {message = "Status not available", data = new {}});
        }
        //check if real estate type is changed
        if (realEstateUpdateDto.TypeId != null && realEstateUpdateDto.TypeId != realEstate.type.Id)
        {
            //find real estate type by id
            var realEstateType = await _realEstateServices.GetRealEstateType((int)realEstateUpdateDto.TypeId);
            if (realEstateType == null)
            {
                return NotFound(new {message = "Real estate type not found", data = new {}});
            }
            realEstate.type = realEstateType;
        }
        await _realEstateServices.UpdateRealEstate(id, realEstate);
        return Ok(new {data = realEstate, message = "Real estate updated successfully"});
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var realEstate = await _realEstateServices.GetRealEstate(id);
        if (realEstate == null)
        {
            return NotFound(new {message = "Real estate not found", data = new {}});
        }
        await _realEstateServices.DeleteRealEstate(id);
        return Ok(new {data = new {}, message = "Real estate deleted successfully"});
    }
}