using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using EduCore.Domain.Results;
using EduCore.Application.Abstracts;
using EduCore.Domain.Enums;

namespace EduCore.Infrastructure.Services;

public class FileService : IFileService
{
    private readonly Cloudinary _cloudinary;

    public FileService(Cloudinary cloudinary)
    {
        _cloudinary = cloudinary;
    }

    public async Task<UploadResultModel> UploadVideoAsync(IFormFile file)
    {
        if (file is null || file.Length == 0)
            return new UploadResultModel { Message = "NoFile" };

        try
        {
            var uploadParams = new VideoUploadParams
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
                UseFilename = true,
                UniqueFilename = true,
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.Error is not null)
                return new UploadResultModel { Message = uploadResult.Error.Message };

            return new UploadResultModel
            {
                Url = uploadResult.SecureUrl?.ToString(),
                PublicId = uploadResult.PublicId,
                ResourceType = uploadResult.ResourceType,
                Duration = TimeSpan.FromSeconds(uploadResult.Duration).ToString(uploadResult.Duration >= 3600 ? @"hh\:mm\:ss" : @"mm\:ss")

            };
        }
        catch (Exception)
        {
            return new UploadResultModel { Message = "FailedToUploadFile" };
        }
    }
    
    public async Task<UploadResultModel> UploadRawFileAsync(IFormFile file)
    {
        if (file is null || file.Length == 0)
            return new UploadResultModel { Message = "NoFile" };

        try
        {
            var uploadParams = new RawUploadParams
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
                UseFilename = true,
                UniqueFilename = true,
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.Error is not null)
                return new UploadResultModel { Message = uploadResult.Error.Message };

            return new UploadResultModel
            {
                Url = uploadResult.SecureUrl?.ToString(),
                PublicId = uploadResult.PublicId,
                ResourceType = uploadResult.ResourceType
            };
        }
        catch (Exception)
        {
            return new UploadResultModel { Message = "FailedToUploadFile" };
        }
    }

    public async Task<string> DeleteAsync(string publicId, string resourceType)
    {
        var deletionParams = new DeletionParams(publicId)
        {
            ResourceType = (ResourceType)Enum.Parse(typeof(ResourceType), resourceType, ignoreCase: true),
            Invalidate = true
        };

        var deletionResult = await _cloudinary.DestroyAsync(deletionParams);
        return deletionResult.Result;
    }
}