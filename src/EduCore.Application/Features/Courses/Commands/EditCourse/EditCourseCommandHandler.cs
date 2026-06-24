using AutoMapper;
using EduCore.Application.Bases;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Features.Courses.Commands.EditCourse;

public sealed class EditCourseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<EditCourseCommand, Result>
{
    public async Task<Result> Handle(EditCourseCommand request, CancellationToken cancellationToken)
    {
        var oldCourse = await unitOfWork.Courses.GetTableNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id);
        if (oldCourse == null)
            return Errors.CourseNotFound;

        var updatedCourse = mapper.Map(request, oldCourse);

        if (request.Thumbnail != null)
        {

        }
        updatedCourse.UpdatedAt = DateTime.UtcNow;
        await unitOfWork.Courses.UpdateAsync(updatedCourse);
        await unitOfWork.SaveChangesAsync();
        return Result.Success();
    }
}
