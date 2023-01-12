
using System.ComponentModel.DataAnnotations;
namespace RealEstateService.Models;

public class RealEstate
{
    [Key]
    public int Id { get; set; }
    public bool Status { get; set; }
    public string Owner { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    // public RealEstateType? type { get; set; }
}