namespace RealEstateService.DTOs;

public class RealEstateDTO
{
    public string? Status { get; set; }
    public string? Owner { get; set; }
    public float? Latitude { get; set; }
    public float? Longitude { get; set; }
    public string? Location { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public float? Area { get; set; }
    public float? CurrentPrice { get; set; }
    public float? Tax { get; set; }
// public RealEstateType? type { get; set; }
}