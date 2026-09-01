using EduCore.Domain.Enums;
using EduCore.Domain.Results;
using Microsoft.AspNetCore.Http;

namespace EduCore.Application.Abstracts;

public interface IFileService
{
    Task<UploadResultModel> UploadVideoAsync(IFormFile file);
    Task<UploadResultModel> UploadRawFileAsync(IFormFile file);
    Task<string> DeleteAsync(string publicId, string resourceType);
}
