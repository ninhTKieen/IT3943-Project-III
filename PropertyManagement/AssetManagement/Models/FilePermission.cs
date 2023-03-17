using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Models;

public class FilePermission
{
    [Key]
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    public int PermissionId { get; set; }
    public int AttachmentFileId { get; set; }
    public int UserId { get; set; }
}