using AssetManagement.Dto;
using AssetManagement.Models;

namespace AssetManagement.Services;

public interface IFileService
{
    string UploadedFile(IFormFile profilePicture);
    Task<Tuple<byte[], string>> GetDownloadDetails(Int64 id);
    Task<AttachmentFile> AddAttachmentFile(FileUploadRequestDto iFormFile);
    Task<List<AttachmentFile>> GetAll();
    Task<AttachmentFile> GetById (Int64 id);
    Task Delete(Int64 id);
}