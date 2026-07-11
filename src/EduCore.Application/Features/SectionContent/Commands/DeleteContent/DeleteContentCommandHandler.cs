using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Features.SectionContent.Commands.DeleteContent;

public sealed class DeleteContentCommandHandler(IUnitOfWork unitOfWork, IFileService fileService) : IRequestHandler<DeleteContentCommand, Result>
{
    public async Task<Result> Handle(DeleteContentCommand request, CancellationToken cancellationToken)
    {
        var content = await unitOfWork.Contents.GetTableNoTracking().Include(x => x.Section).FirstOrDefaultAsync(x => x.Id == request.Id);
        if (content == null) 
            return Errors.ContentNotFound;

        var section = await unitOfWork.Sections.GetTableAsTracking().Include(x => x.Course)
            .FirstOrDefaultAsync(x => x.Id == content.SectionId);

        if (section == null)
            return Errors.SectionNotFound;

        var result = await fileService.DeleteAsync(content.PublicId, content.ResourceType);
        if (result != "ok") return Errors.FailedToDeleteFile;
        await unitOfWork.Contents.DeleteAsync(content);
        section.NoOfLectures--;
        section.Course.NoOfLectures--;
        await unitOfWork.SaveChangesAsync();
        return Result.Success();
    }
}
