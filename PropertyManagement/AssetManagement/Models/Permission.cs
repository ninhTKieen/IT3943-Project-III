using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Models;

public class Permission
{
    [Key]
    public int Id { get; set; }
    public string Action { get; set; }
    public string CreatedAt { get; set; }
    public string UpdatedAt { get; set; }
    
    public ICollection<FilePermission> FilePermissions { get; set; }
}