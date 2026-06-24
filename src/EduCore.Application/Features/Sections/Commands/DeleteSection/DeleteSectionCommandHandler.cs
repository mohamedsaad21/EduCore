using EduCore.Application.Bases;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Features.Sections.Commands.DeleteSection;

public sealed class DeleteSectionCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteSectionCommand, Result>
{
    public async Task<Result> Handle(DeleteSectionCommand request, CancellationToken cancellationToken)
    {
        var Section = await unitOfWork.Sections.GetTableNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id);
        if (Section == null) return Errors.SectionNotFound;
        await unitOfWork.Sections.DeleteAsync(Section);
        await unitOfWork.SaveChangesAsync();
        return Result.Success();
    }
}
