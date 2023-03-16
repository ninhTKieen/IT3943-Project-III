using AssetManagement.Data;
using AssetManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Services;

public class FileService :IFileService
{
    private readonly  IWebHostEnvironment _hostingEnvironment;
    private readonly ApplicationDbContext _context;
    
    public FileService(IWebHostEnvironment hostingEnvironment, ApplicationDbContext context)
    {
        _hostingEnvironment = hostingEnvironment;
        _context = context;
    }
    
    public string UploadedFile(IFormFile profilePicture)
    {
        string profilePictureName = null;
        if (profilePicture != null)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.ContentRootPath, "upload");
            if (profilePicture.Name == null)
            {
                profilePictureName = Guid.NewGuid().ToString() + "_" + "black-person.png";
            }
            else
            {
                profilePictureName = Guid.NewGuid().ToString() + "_" + profilePicture.FileName;
            }
            string filePath = Path.Combine(uploadsFolder, profilePictureName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                profilePicture.CopyTo(fileStream);
            }

            return profilePictureName;
        }
        
        return "black-person.png";
    }

    public async Task<Tuple<byte[], string>> GetDownloadDetails(long id)
    {
        byte[] bytes = null;
        try
        {
            var attachmentFile = await _context.AttachmentFiles.Where(x => x.Id == id).SingleOrDefaultAsync();
            string _WebRootPath = _hostingEnvironment.ContentRootPath + attachmentFile.FilePath;
            bytes = File.ReadAllBytes(_WebRootPath);

            var tuple = new Tuple<byte[], string>(bytes, attachmentFile.FileName);
            return tuple;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<AttachmentFile> AddAttachmentFile(IFormFile _formFile)
    {
        try
        {
            string fileName = UploadedFile(_formFile);
            AttachmentFile attachmentFile = new AttachmentFile
            {
                FilePath = "/upload/" + fileName,
                ContentType = _formFile.ContentType,
                FileName = fileName,
                Length = _formFile.Length,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                CreatedBy = "Admin",
                ModifiedBy = "Admin",
            };
            _context.AttachmentFiles.Add(attachmentFile);
            await _context.SaveChangesAsync();
            return attachmentFile;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}