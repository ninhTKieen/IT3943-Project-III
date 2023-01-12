using System.ComponentModel.DataAnnotations;

namespace DeviceManagement.Models;

public class Device
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Sku { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public float Latitude { get; set; }
    public float Longitude { get; set; }
    public string Position { get; set; }
    public int Cost { get; set; }
    public string Origin { get; set; }
    public string Status { get; set; }
    public string Type { get; set; }
    public string Brand { get; set; }
    public string Owner { get; set; }
    
    public DateTime PurchaseDate { get; set; }
    public DateTime? WarrantyDate { get; set; }
    public DateTime? LastServiceDate { get; set; }
    public DateTime InstallationDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
}