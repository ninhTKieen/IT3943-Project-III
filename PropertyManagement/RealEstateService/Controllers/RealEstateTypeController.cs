using Microsoft.AspNetCore.Mvc;
using RealEstateService.DTOs;
using RealEstateService.Services;

namespace RealEstateService.Controllers;

[ApiController]
[Route("api/RealEstateType")]
public class RealEstateTypeController : ControllerBase
{
    private ResponseDto _response;
    private RealEstateTypeService _realEstateTypeService;
    
    public RealEstateTypeController(RealEstateTypeService realEstateTypeService)
    {
        _realEstateTypeService = realEstateTypeService;
        this._response = new ResponseDto();
    }
    
    [HttpGet]
    public async Task<Object> Get()
    {
        try
        {
            var realEstateTypes = await _realEstateTypeService.GetRealEstateTypes();
            _response.Result = realEstateTypes;
            _response.IsSuccess = true;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }

        return _response;
    }
    
    [HttpGet("{id}")]
    public async Task<Object> GetById(int id)
    {
        try
        {
            var realEstateType = await _realEstateTypeService.GetRealEstateTypeById(id);
            _response.Result = realEstateType;
            _response.IsSuccess = true;
            if (realEstateType is null)
            {
                _response.DisplayMessage = "No item found!";
            }
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }

        return _response;
    }
    
    [HttpPost]
    public async Task<Object> Post([FromBody] RealEstateTypeDTO realEstateTypeDto)
    {
        try
        {
            var realEstateType = await _realEstateTypeService.CreateRealEstateType(realEstateTypeDto);
            _response.Result = realEstateType;
            _response.IsSuccess = true;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }

        return _response;
    }
    
    [HttpPut("{id}")]
    public async Task<Object> Put(int id, [FromBody] RealEstateTypeDTO realEstateTypeDto)
    {
        try
        {
            var realEstateType = await _realEstateTypeService.UpdateRealEstateType(id, realEstateTypeDto);
            _response.Result = realEstateType;
            _response.IsSuccess = true;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }

        return _response;
    }
    
    [HttpDelete("{id}")]
    public async Task<Object> Delete(int id)
    {
        try
        {
            var realEstateType = await _realEstateTypeService.DeleteRealEstateType(id);
            _response.Result = realEstateType;
            _response.IsSuccess = true;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }

        return _response;
    }
}