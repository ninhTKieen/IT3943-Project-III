using System.ComponentModel.DataAnnotations;

namespace EstateManagement.Dtos;

public class EstateTypeDto
{
    
}

public class RealEstateTypeCreateDto
{
    [Required]
    public string Name { get; set; }
    
    public string Description { get; set; }
}

public class RealEstateTypeUpdateDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}