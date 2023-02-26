using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DeviceManagement.Dtos;

public class DeviceCreateDto
{
    [Required]
    public string Name { get; set; }
    public string Sku { get; set; } = "N/A";
    [Required]
    public string Description { get; set; }

    public string ImageUrl { get; set; } = "";
    [Required]
    public float Latitude { get; set; }
    [Required]
    public float Longitude { get; set; }
    [Required]
    public string Position { get; set; }
    [Required]
    public int Cost { get; set; }

    public string Origin { get; set; } = "";
    public string Type { get; set; }= "";
    public string Brand { get; set; }= "";
    [Required]
    public string Owner { get; set; }
    [Required]
    public string Manager { get; set; }
    
    public DateTime? PurchaseDate { get; set; }
    public DateTime? WarrantyDate { get; set; }
}

public class DeviceUpdateDto
{
    public string Name { get; set; }
    public string Sku { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public float Latitude { get; set; }
    public float Longitude { get; set; }
    public string Position { get; set; }
    public int Cost { get; set; }
    public string Origin { get; set; }
    public int Status { get; set; }
    public string Type { get; set; }
    public string Brand { get; set; }
    public string Owner { get; set; }
    public string Manager { get; set; }

    public DateTime? PurchaseDate { get; set; }
    public DateTime? WarrantyDate { get; set; }
    public DateTime? LastServiceDate { get; set; }
    public DateTime? InstallationDate { get; set; }
}

public class DeviceResponse
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
    public int Status { get; set; }
    public string Type { get; set; }
    public string Brand { get; set; }
    public string Owner { get; set; }
    public string Manager { get; set; }

    public DateTime PurchaseDate { get; set; }
    public DateTime WarrantyDate { get; set; }
    public DateTime LastServiceDate { get; set; }
    public DateTime InstallationDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public IEnumerable<MaintenanceResponse> MaintenanceHistories { get; set; } = Array.Empty<MaintenanceResponse>();
}

public class MaintenanceResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}
public class DevicePreviewDto
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Sku { get; set; }
    public string Description { get; set; }
}

public class Response<T>
{
    public Response(IEnumerable<T> results = null)
    {
        Results = results ?? Array.Empty<T>();
    }
    
    public IEnumerable<T> Results { get; set; }
}