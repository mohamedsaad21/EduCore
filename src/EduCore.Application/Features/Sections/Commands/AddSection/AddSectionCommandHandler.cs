using AutoMapper;
using EduCore.Application.Bases;
using EduCore.Domain.Entities;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Features.Sections.Commands.AddSection;

public sealed class AddSectionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<AddSectionCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(AddSectionCommand request, CancellationToken cancellationToken)
    {
        var course = await unitOfWork.Courses.GetTableAsTracking().FirstOrDefaultAsync(x => x.Id == request.CourseId);
        
        if (course == null)
            return Errors.CourseNotFound;

        var section = mapper.Map<Section>(request);
        await unitOfWork.Sections.AddAsync(section);
        course.NoOfSections++;
        await unitOfWork.SaveChangesAsync();        
        return section.Id;
    }
}
