using AuthService.Data;
using AuthService.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Services;

public class UserService
{
    private readonly ApplicationDbContext _context;

    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User?> Create(User? user)
    {
        PasswordHasher<User?> passwordHasher = new();
        string hashedPassword = passwordHasher.HashPassword(user, user?.Password);
        user.Password = hashedPassword;
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        
        return user;
    }

    public async Task<User> Get(string email)
    {
        var res = await _context.Users.Where(t => t.Email == email).FirstOrDefaultAsync();
        return res;
    }
}