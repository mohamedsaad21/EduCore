using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Features.SectionContent.Commands.EditContent;

public sealed class EditContentCommandHandler(IUnitOfWork unitOfWork, IFileService fileService) : IRequestHandler<EditContentCommand, Result>
{
    public async Task<Result> Handle(EditContentCommand request, CancellationToken cancellationToken)
    {
        var content = await unitOfWork.Contents.GetTableAsTracking().FirstOrDefaultAsync(x => x.Id == request.Id);
        if (content == null)
            return Errors.ContentNotFound;

        content.Title = request.Title;
        content.SectionId = request.SectionId;

        if (request.Attachment != null)
        {
            await fileService.DeleteAsync(content.PublicId, content.ResourceType);
            var uploadResult = await fileService.UploadAsync(request.Attachment);
            content.Url = uploadResult.Url;
            content.PublicId = uploadResult.PublicId;
        }
        await unitOfWork.SaveChangesAsync();
        return Result.Success();
    }

}
