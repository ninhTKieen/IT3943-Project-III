using Microsoft.AspNetCore.Mvc;
using RealEstateService.DTOs;

namespace RealEstateService.Controllers;
[ApiController]
[Route("api/RealEstate")]
public class RealEstateController : ControllerBase
{
    private ResponseDto _response;
    private Services.RealEstateService _realEstateService;
    // GET
    
    public RealEstateController(Services.RealEstateService realEstateService)
    {
        _realEstateService = realEstateService;
        this._response = new ResponseDto();
    }

    [HttpGet]
    public async Task<Object> Get()
    {
        try
        {
            var realEstates = await _realEstateService.GetRealEstates();
            _response.Result = realEstates;
            _response.IsSuccess = true;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }

        return _response;
    }
    
    
    [HttpPost]
    public async Task<Object> Post([FromBody] RealEstateDTO realEstate)
    {
        try
        {
            var realEstateId = await _realEstateService.CreateRealEstate(realEstate);
            _response.Result = realEstateId;
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
    public async Task<Object> Get(int id)
    {
        try
        {
            var realEstate = await _realEstateService.GetRealEstateById(id);
            _response.Result = realEstate;
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
    public async Task<Object> Put(int id, [FromBody] RealEstateDTO realEstate)
    {
        try
        {
            var realEstateId = await _realEstateService.UpdateRealEstate(id, realEstate);
            _response.Result = realEstateId;
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
            var realEstateId = await _realEstateService.DeleteRealEstate(id);
            _response.Result = realEstateId;
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