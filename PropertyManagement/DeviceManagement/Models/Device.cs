using System.ComponentModel.DataAnnotations;

namespace DeviceManagement.Models;

public class Device
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
}