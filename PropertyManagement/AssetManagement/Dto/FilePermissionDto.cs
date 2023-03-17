namespace AssetManagement.Dto;

public class FilePermissionDto
{
    
}

public class CreateFilePermissionDto
{
    public int PermissionId { get; set; }
    public int AttachmentFileId { get; set; }
    public int UserId { get; set; }
}

public class UpdateFilePermissionDto
{
    public int? PermissionId { get; set; }
    public int? AttachmentFileId { get; set; }
}