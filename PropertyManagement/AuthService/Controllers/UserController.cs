using System.Security.Claims;
using AuthService.Dto;
using AuthService.Models;
using AuthService.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers;

[ApiController]
[Route("api/user")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly UserService _userService;
    
    public UserController(UserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpPut("/update")]
    public async Task<ActionResult<User>> Update([FromBody] UpdateProfileDto userUpdateDto)
    {
        try
        {
            //parse int from claim
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.Name));
            
            var oldUser = await _userService.Get(userId);
            
            //keep old values if new values are null
            _mapper.Map<UpdateProfileDto, User>(userUpdateDto, oldUser);
            
            await _userService.Update(oldUser);
            return Ok(new {data = oldUser, message = "User updated successfully"});
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    
}
