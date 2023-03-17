namespace AssetManagement.Models;

public class AttachmentFile : EntityBase
{
    public Int64 Id { get; set; }
    public string FilePath { get; set; } = "/upload/blank-doc.txt";
    public string ContentType { get; set; }
    public string FileName { get; set; }
    public string Sku { get; set; }
    public string Category { get; set; }
    public Int64 Length { get; set; }
    
    public ICollection<FilePermission> FilePermissions { get; set; }
}