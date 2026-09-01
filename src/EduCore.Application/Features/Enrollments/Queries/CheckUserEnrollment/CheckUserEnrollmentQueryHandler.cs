using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Core.Features.Enrollments.Queries.CheckUserEnrollment;

public class CheckUserEnrollmentQueryHandler(ICurrentUserService currentUserService, IUnitOfWork unitOfWork) : IRequestHandler<CheckUserEnrollmentQuery, Result<bool>>
{
    public async Task<Result<bool>> Handle(CheckUserEnrollmentQuery request, CancellationToken cancellationToken)
    {
        var course = await unitOfWork.Courses.GetTableNoTracking().FirstOrDefaultAsync(x => x.Id == request.CourseId);
        
        if (course == null)
            return Errors.CourseNotFound;
        
        var user = await currentUserService.GetCurrentUserAsync();

        if (user == null)
            return Errors.Unauthorized;

        var isEnrolled = await unitOfWork.Enrollments.GetTableNoTracking()
            .AnyAsync(x => x.CourseId == course.Id && x.UserId == user.Id);

        return isEnrolled;
    }
}