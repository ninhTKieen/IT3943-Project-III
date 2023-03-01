using AuthService.Dto;
using AuthService.Models;
using AuthService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers;

[AllowAnonymous]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    // GET
    private readonly AuthenticationService _authService;
    private readonly UserService _userService;
    public AuthController(AuthenticationService authService, UserService userService)
    {
        this._authService = authService;
        this._userService = userService;
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto user)
    {
        var token = await _authService.Login(user.Email, user.Password);
        
        if (token == null)
            return new UnauthorizedResult();
        return Ok(new {token, message="Login successful", data = new {}});
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto user)
    {
        if (!ModelState.IsValid)
        {
            return new BadRequestObjectResult(ModelState);
        }
        //logging user to console
        Console.WriteLine(user.Password);
        var emailExist = await _userService.Get(user.Email);
        if (emailExist != null)
        {
            return new BadRequestObjectResult(
                new {
                    message = "Email already exists",
                    data = new {}
                });
        }
        var token = await _authService.Register(user)!;
        if(token == null)
            return new BadRequestObjectResult(
                new {
                    message = "Something went wrong",
                    data = new {}
                });
        
        return Ok(new {token, message="Register complete", data = new {} });
    }
}
