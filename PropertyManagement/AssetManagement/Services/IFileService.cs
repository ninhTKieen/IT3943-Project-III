using AssetManagement.Models;

namespace AssetManagement.Services;

public interface IFileService
{
    string UploadedFile(IFormFile profilePicture);
    Task<Tuple<byte[], string>> GetDownloadDetails(Int64 id);
    Task<AttachmentFile> AddAttachmentFile(IFormFile iFormFile);
}