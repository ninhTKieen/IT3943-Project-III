using System.ComponentModel.DataAnnotations;

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