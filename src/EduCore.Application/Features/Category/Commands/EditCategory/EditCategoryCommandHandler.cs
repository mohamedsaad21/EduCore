using AutoMapper;
using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Domain.Enums;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Features.Category.Commands.EditCategory;

public sealed class EditCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService) : IRequestHandler<EditCategoryCommand, Result>
{
    public async Task<Result> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
    {
        var oldCategory = await unitOfWork.Categories.GetTableNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id);
        if (oldCategory == null) 
            return Errors.CategoryNotFound;

        var updatedCategory = mapper.Map(request, oldCategory);
        //updatedCategory.ThumbnailUrl = oldCategory.ThumbnailUrl;
        if (request.Thumbnail != null)
        {
            await fileService.DeleteAsync(oldCategory.ThumbnailPublicId, "Image");
            var result = await fileService.UploadAsync(request.Thumbnail);
            updatedCategory.ThumbnailUrl = result.Url;
            updatedCategory.ThumbnailPublicId = result.PublicId;
        }

        await unitOfWork.Categories.UpdateAsync(updatedCategory);
        await unitOfWork.SaveChangesAsync();
        return Result.Success();
    }
}
