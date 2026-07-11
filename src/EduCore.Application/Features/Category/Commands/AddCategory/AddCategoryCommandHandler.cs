using AutoMapper;
using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Core.Features.Category.Commands.Models;
using EduCore.Domain.Entities;
using EduCore.Domain.Enums;
using EduCore.Domain.Interfaces;
using MediatR;

namespace EduCore.Application.Features.Category.Commands.AddCategory;

public sealed class AddCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService) : IRequestHandler<AddCategoryCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = mapper.Map<CourseCategory>(request);

        await unitOfWork.Categories.AddAsync(category);
        if (request.Thumbnail != null)
        {
            var result = await fileService.UploadAsync(request.Thumbnail);
            category.ThumbnailUrl = result.Url;
            category.ThumbnailPublicId = result.PublicId;
        }
        await unitOfWork.SaveChangesAsync();
        return category.Id;
    }
}
