using AuthService.Data;
using AuthService.Dto;
using AuthService.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Services;

public class AuthenticationService
{
    private readonly ApplicationDbContext _context;
    private readonly TokenService _tokenService;
    private readonly UserService _userService;
    private readonly IMapper _mapper;
    
    public AuthenticationService(ApplicationDbContext context, TokenService tokenService, UserService userService, IMapper mapper)
    {
        _context = context;
        _tokenService = tokenService;
        _userService = userService;
        _mapper = mapper;
    }
    
    public async Task<string> Login(string mail, string password)
    {
        var user = await _userService.Get(mail);
        if (user == null)
        {
            return null;
        }
        //verify password derivation
        PasswordHasher<User> passwordHasher = new();
        if(passwordHasher.VerifyHashedPassword(user, user.Password, password) == PasswordVerificationResult.Success)
        {
            var token = _tokenService.GenerateToken(user);
            return token;
        } else
        {
            return null;
        }
    }

    public async Task<string> Register(RegisterDto userRegisterDto)
    {
        if (!Equals(userRegisterDto.Password, userRegisterDto.ConfirmPassword))
        {
            return null;
        }
    
        var user = _mapper.Map<User>(userRegisterDto);
        
        await _userService.Create(user);
        
        return _tokenService.GenerateToken(user);
    }
}