using EstateManagement.Models;

namespace EstateManagement.Dtos;

public class RealEstateDto
{
    
}

public class RealEstateCreateDto
{
    public int Status { get; set; }
    public float Latitude { get; set; }
    public float Longitude { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public float Area { get; set; }
    public string ImageUrl { get; set; }
    public float CurrentPrice { get; set; }
    public float Tax { get; set; }
    public int TypeId { get; set; }
}

public class RealEstateUpdateDto
{
    public int? Status { get; set; }
    public float? Latitude { get; set; }
    public float? Longitude { get; set; }
    public string? Location { get; set; }
    public string? Description { get; set; }
    public float? Area { get; set; }
    public string? ImageUrl { get; set; }
    public float? CurrentPrice { get; set; }
    public float? Tax { get; set; }
    public int? TypeId { get; set; }
}