using System.ComponentModel.DataAnnotations;

namespace DeviceManagement.Dtos;

public class DeviceCreateDto
{
    [Required]
    public string Name { get; set; }
}