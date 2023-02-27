using DeviceManagement.Data;
using DeviceManagement.Dtos;
using DeviceManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeviceManagement.Services;

public class CategoryService
{
    private readonly ApplicationDbContext _context;
    public CategoryService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Category> Create (Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        return category;
    }
    
    public async Task<Category> Update (Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task Delete (Category category)
    {
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
    }

    public async Task<Category> Get (int id)
    {
        var category = await _context.Categories.FindAsync(id);
        return category;
    }
    
    public async Task<List<Category>> GetAll ()
    {
        var categories = await _context.Categories.Where(s=> true).ToListAsync();
        return categories;
    }
}