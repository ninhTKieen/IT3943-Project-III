using System.ComponentModel.DataAnnotations;
using DeviceManagement.Models;

namespace DeviceManagement.Dtos;

public class MaintenanceCreateDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public int Expenses { get; set; } //cost
    
    [Required]
    public  DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    
    [Required]
    public int Type { get; set; }
    public string Description { get; set; }
    public string Note { get; set; }
    public int? Status { get; set; }

    [Required]
    public int DeviceId { get; set; }
}

public class MaintenanceDto
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Expenses { get; set; } //cost
    
    public  DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
    public int Type { get; set; }
    public string Description { get; set; }
    public int Status { get; set; }
    public string Note { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    public int DeviceId { get; set; }
    public virtual Device Device { get; set; }
}

public class MaintenancePreviewDto
{
    public string Name { get; set; }
    public int Expenses { get; set; } //cost
    
    public  DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}