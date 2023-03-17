namespace AssetManagement.Dto;

public class FileUploadRequestDto
{
    public string? CreatedBy { get; set; }
    public string? ModifiedBy { get; set; }
    
    public string Sku { get; set; }
    public string Category { get; set; }
    public IFormFile File { get; set; }    
}
