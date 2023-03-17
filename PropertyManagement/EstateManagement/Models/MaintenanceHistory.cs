using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EstateManagement.Models;

public class MaintenanceHistory
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Expenses { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Type { get; set; }
    public string Creater { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int RealEstateId { get; set; }
    [JsonIgnore]
    public RealEstate RealEstate { get; set; }
}

public class MaintenanceHistoryWithoutRealEstate
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Expenses { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Type { get; set; }
    public string Creater { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}