using AuthService.Dto;
using AuthService.Models;
using AuthService.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers;

[ApiController]
[Route("api/admin")]
[Authorize(Roles = "admin")]
public class AdminController : ControllerBase
{
    private readonly UserService _userService;
    private readonly IMapper _mapper;
    
    public AdminController(UserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpGet("getAll")]
    public async Task<ActionResult<List<User>>> GetAllUser()
    {
        try
        {
            var users = await _userService.Get();
            return Ok(new {data = users, message = "Users found"});
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }   
    }
    
    [HttpGet("get/{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        try
        {
            var user = await _userService.Get(id);
            if (user == null)
            {
                return NotFound(new {message = "User not found", data = new {}});
            }
            return Ok(new {data = user, message = "User found"});
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpPut("update/{id}")]
    public async Task<ActionResult<User>> UpdateUser(int id, [FromBody] AdminUpdateProfileDto userUpdateDto)
    {
        try
        {
            var oldUser = await _userService.Get(id);
            
            if (oldUser == null)
            {
                return NotFound(new {message = "User not found", data = new {}});
            }
            
            _mapper.Map<AdminUpdateProfileDto, User>(userUpdateDto, oldUser);
            
            await _userService.Update(oldUser);
            return Ok(new {data = oldUser, message = "User updated successfully"});
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpDelete("delete/{id}")]
    public async Task<ActionResult<User>> DeleteUser(int id)
    {
        try
        {
            var user = await _userService.Get(id);
            
            if (user == null)
            {
                return NotFound(new {message = "User not found", data = new {}});
            }
            
            await _userService.Delete(id);
            return Ok(new {data = user, message = "User deleted successfully"});
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}