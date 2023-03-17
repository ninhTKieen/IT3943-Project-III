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
    
    public async Task<User> Get(int id)
    {
        var res = await _context.Users.Where(t => t.Id == id).FirstOrDefaultAsync();
        return res;
    }

    public async Task<List<User>> Get()
    {
        var res = await _context.Users.ToListAsync();
        return res;
    }

    public async Task Update(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
    
    public async Task Delete(int id)
    {
        var user = await _context.Users.Where(t => t.Id == id).FirstOrDefaultAsync();
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    public async Task ChangePassword(User user, string newPassword)
    {
        PasswordHasher<User?> passwordHasher = new();
        string hashedPassword = passwordHasher.HashPassword(user, newPassword);
        
        user.Password = hashedPassword;
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
}