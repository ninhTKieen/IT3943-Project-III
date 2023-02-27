using AutoMapper;
using DeviceManagement.Dtos;
using DeviceManagement.Models;
using DeviceManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeviceManagement.Controllers;

[ApiController]
[Route("api/category")]
public class CategoryController : Controller
{
    private readonly CategoryService _categoryService;
    private readonly IMapper _mapper;
    
    public CategoryController(CategoryService categoryService, IMapper mapper)
    {
        _categoryService = categoryService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult<Category>> Create([FromBody] CategoryCreateDto categoryCreateDto)
    {
        try
        {
            var category = _mapper.Map<Category>(categoryCreateDto);
            var newCategory = await _categoryService.Create(category);
            return Ok(new {data = newCategory, message = "Category created successfully"});
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetById(int id)
    {
        try
        {
            var category = await _categoryService.Get(id);
            if (category == null)
            {
                return NotFound(new {message = "Category not found", data = new {}});
            }
            return Ok(new {data = category, message = "Category found"});
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpGet]
    public async Task<ActionResult<Category>> GetAll()
    {
        try
        {
            var categories = await _categoryService.GetAll();
            if (categories == null)
            {
                return NotFound(new {message = "Category not found", data = new {}});
            }
            return Ok(new {data = categories, message = "Category found"});
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<Category>> Update([FromBody] CategoryUpdateDto categoryUpdateDto, int id)
    {
        try
        {
            var category = await _categoryService.Get(id);
            
            if (category == null)
            {
                return NotFound(new {message = "Category not found", data = new {}});
            }
            
            _mapper.Map(categoryUpdateDto, category);
            var newCategory = await _categoryService.Update(category);
            return Ok(new {data = newCategory, message = "Category updated successfully"});
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var category = await _categoryService.Get(id);
            
            if (category == null)
            {
                return NotFound(new {message = "Category not found", data = new {}});
            }
            
            await _categoryService.Delete(category);
            return Ok(new {data = new {}, message = "Category deleted successfully"});
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}