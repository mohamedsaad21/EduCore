using AutoMapper;
using EduCore.Application.Bases;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Features.Sections.Commands.EditSection;

public sealed class EditSectionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<EditSectionCommand, Result>
{
    public async Task<Result> Handle(EditSectionCommand request, CancellationToken cancellationToken)
    {
        var oldSection = await unitOfWork.Sections.GetTableNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id);
        if (oldSection == null) return Errors.SectionNotFound;

        var newSection = mapper.Map(request, oldSection);
        await unitOfWork.Sections.UpdateAsync(newSection);
        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
