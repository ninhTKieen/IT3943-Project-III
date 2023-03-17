using AutoMapper;
using EstateManagement.Dtos;
using EstateManagement.Models;
using EstateManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace EstateManagement.Controllers;

[ApiController]
[Route("api/EstateType")]
public class RealEstateTypeController: Controller
{
    private readonly RealEstateTypeServices _estateTypeServices;
    private readonly IMapper _mapper;

    public RealEstateTypeController(RealEstateTypeServices _realEstateTypeServices, IMapper _mapper)
    {
        _estateTypeServices = _realEstateTypeServices;
        this._mapper = _mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var estateTypes = await _estateTypeServices.GetAll();
        return Ok(new {data = estateTypes, message = "Estate types found"});
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var estateType = await _estateTypeServices.Get(id);
        if (estateType == null)
        {
            return NotFound(new {message = "Estate type not found"});
        }
        return Ok(new {data = estateType, message = "Estate type found"});
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RealEstateTypeCreateDto realEstateTypeCreateDto)
    {
        var estateType =  _mapper.Map<RealEstateType>(realEstateTypeCreateDto);
        var newEstateType = await _estateTypeServices.Create(estateType);
        return Ok(new {data = newEstateType, message = "Estate type created"});
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] RealEstateTypeUpdateDto realEstateTypeUpdateDto)
    {
        var estateType = await _estateTypeServices.Get(id);
        if (estateType == null)
        {
            return NotFound(new {message = "Estate type not found"});
        }
        estateType.Name = realEstateTypeUpdateDto.Name ?? estateType.Name;
        estateType.Description = realEstateTypeUpdateDto.Description ?? estateType.Description;
        estateType.UpdatedAt = DateTime.Now;
        var updatedEstateType = await _estateTypeServices.Update(estateType);
        return Ok(new {data = updatedEstateType, message = "Estate type updated"});
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var estateType = await _estateTypeServices.Get(id);
        if (estateType == null)
        {
            return NotFound(new {message = "Estate type not found"});
        }
        await _estateTypeServices.Delete(id);
        return Ok(new {data = estateType, message = "Estate type deleted"});
    }
}