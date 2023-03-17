using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EstateManagement.Models;

public class RealEstate
{
    [Key]
    public int Id { get; set; }
    public int Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public float Latitude { get; set; }
    public float Longitude { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public float Area { get; set; }
    public string ImageUrl { get; set; }
    public float CurrentPrice { get; set; }
    public float Tax { get; set; }
    public RealEstateType type { get; set; }
    public ICollection<MaintenanceHistory> MaintenanceHistories { get; set; }
}