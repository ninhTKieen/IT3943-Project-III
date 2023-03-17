using System.ComponentModel.DataAnnotations;

namespace EstateManagement.Dtos;

public class MaintenanceHistoryDto
{
    
}

public class MaintenanceHistoryCreateDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public double Expenses { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
    [Required]
    public int Type { get; set; }
    [Required]
    public string Creater { get; set; }
    [Required]
    public int RealEstateId { get; set; }
}

public class MaintenanceHistoryUpdateDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double? Expenses { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? Type { get; set; }
    public string? Creater { get; set; }
    public int? RealEstateId { get; set; }
}