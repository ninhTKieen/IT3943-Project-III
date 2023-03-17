using System.ComponentModel.DataAnnotations;

namespace EstateManagement.Models;

public class RealEstateType
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}