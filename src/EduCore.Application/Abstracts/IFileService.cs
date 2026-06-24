using EduCore.Domain.Results;
using Microsoft.AspNetCore.Http;

namespace EduCore.Application.Abstracts;

public interface IFileService
{
    Task<UploadResultModel> UploadAsync(IFormFile file);
    Task<string> DeleteAsync(string publicId, string resourceType);
}
