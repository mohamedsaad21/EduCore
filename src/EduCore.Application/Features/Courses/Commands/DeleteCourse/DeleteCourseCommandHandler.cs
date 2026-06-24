using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Domain.Enums;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Features.Courses.Commands.DeleteCourse;

public sealed class DeleteCourseCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IFileService fileService) : IRequestHandler<DeleteCourseCommand, Result>
{
    public async Task<Result> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
    {
        var course = await unitOfWork.Courses.GetTableNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id);
        if (course == null) 
            return Errors.CourseNotFound;

        var currentInstructorId = await currentUserService.GetCurrentUserId();

        if (course.InstructorId != currentInstructorId)
            return Errors.UnauthorizedCourseAccess;

        if (course.Thumbnail != null)
        {
            await fileService.DeleteAsync(course.ThumbnailPublicId, "Image");
        }
        await unitOfWork.Courses.DeleteAsync(course);
        await unitOfWork.SaveChangesAsync();
        return Result.Success();
    }
}
