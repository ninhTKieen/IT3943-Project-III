using System.ComponentModel.DataAnnotations;

namespace RealEstateService.DTOs;

public class RealEstateTypeDTO
{
    public string? Name { get; set; }
    
    public string? Description { get; set; }
}