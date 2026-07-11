using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Features.CourseProgress.Queries.GetCourseProgress;

public sealed class GetCourseProgressQueryHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IEnrollmentService enrollmentService) : IRequestHandler<GetCourseProgressQuery, Result<GetCourseProgressResponse>>
{
    public async Task<Result<GetCourseProgressResponse>> Handle(GetCourseProgressQuery request, CancellationToken cancellationToken)
    {
        var course = await unitOfWork.Courses.GetTableNoTracking().FirstOrDefaultAsync(x => x.Id == request.CourseId);
        if (course == null)
            return Errors.CourseNotFound;

        var user = await currentUserService.GetCurrentUserAsync();
        // Check if user enrolled in course
        var Enrolled = await enrollmentService.CheckEnrollmentAsync(course, user);
        if (!Enrolled)
            return Errors.NotEnrolledInCourse;

        var totalContent = await unitOfWork.Contents.GetTableNoTracking().CountAsync(c => c.Section.CourseId == course.Id);
        var totalCompleted =
            await unitOfWork.UserCourseProgresses.GetTableNoTracking().CountAsync(p => p.UserId == user.Id && p.Content.Section.CourseId == course.Id && p.IsCompleted);
        var percent = Math.Round(((double)totalCompleted / totalContent) * 100, 2);
        return new GetCourseProgressResponse { TotalContent = totalContent, TotalCompleted = totalCompleted, Percent = percent };
    }
}
