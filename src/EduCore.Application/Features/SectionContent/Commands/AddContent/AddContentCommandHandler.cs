using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Features.SectionContent.Commands.AddContent;

public sealed class AddContentCommandHandler(IUnitOfWork unitOfWork, IFileService fileService) : IRequestHandler<AddContentCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(AddContentCommand request, CancellationToken cancellationToken)
    {
        // Upload File
        var section = await unitOfWork.Sections.GetTableNoTracking().FirstOrDefaultAsync(x => x.Id == request.SectionId);
        var uploadResult = await fileService.UploadAsync(request.File);

        var content = new Domain.Entities.SectionContent
        {
            Title = request.Title,
            Url = uploadResult.Url,
            PublicId = uploadResult.PublicId,
            ResourceType = uploadResult.ResourceType,
            Duration = uploadResult.Duration,
            SectionId = request.SectionId,
        };
        await unitOfWork.Contents.AddAsync(content);
        await unitOfWork.SaveChangesAsync();
        return content.Id;
    }
}
