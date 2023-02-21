using System.ComponentModel.DataAnnotations;

namespace DeviceManagement.Models;

public class MaintenanceHistory
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
    public Device Device { get; set; }
}
