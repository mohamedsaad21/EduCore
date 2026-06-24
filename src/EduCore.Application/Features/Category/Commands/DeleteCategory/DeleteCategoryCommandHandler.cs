using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Domain.Enums;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Features.Category.Commands.DeleteCategory;

public sealed class DeleteCategoryCommandHandler(IUnitOfWork unitOfWork, IFileService fileService) : IRequestHandler<DeleteCategoryCommand, Result>
{
    public async Task<Result> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await unitOfWork.Categories.GetTableNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id);
        if (category == null)
            return Errors.CategoryNotFound;

        if (category.ThumbnailUrl != null)
        {
            await fileService.DeleteAsync(category.ThumbnailPublicId, "Image");
        }
        await unitOfWork.Categories.DeleteAsync(category);
        await unitOfWork.SaveChangesAsync();
        return Result.Success();
    }
}
