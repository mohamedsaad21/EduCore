using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Domain.Enums;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Features.SectionContent.Commands.DeleteContent;

public sealed class DeleteContentCommandHandler(IUnitOfWork unitOfWork, IFileService fileService) : IRequestHandler<DeleteContentCommand, Result>
{
    public async Task<Result> Handle(DeleteContentCommand request, CancellationToken cancellationToken)
    {
        var content = await unitOfWork.Contents.GetTableNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id);
        if (content == null) return Errors.ContentNotFound;

        var result = await fileService.DeleteAsync(content.PublicId, content.ResourceType);
        if (result != "ok") return Errors.FailedToDeleteFile;
        await unitOfWork.Contents.DeleteAsync(content);
        await unitOfWork.SaveChangesAsync();
        return Result.Success();
    }
}
