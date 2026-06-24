using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Application.Wrappers;
using EduCore.Domain.Interfaces;
using MediatR;

namespace EduCore.Application.Features.Enrollments.Queries.GetUserEnrollmentsPaginatedList;

public sealed class GetUserEnrollmentsPaginatedListQueryHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService) : IRequestHandler<GetUserEnrollmentsPaginatedListQuery, Result<PaginatedResult<GetUserEnrollmentsPaginatedListResponse>>>
{
    public async Task<Result<PaginatedResult<GetUserEnrollmentsPaginatedListResponse>>> Handle(GetUserEnrollmentsPaginatedListQuery request, CancellationToken cancellationToken)
    {
        var userId = await currentUserService.GetCurrentUserId();
        var enrollments = unitOfWork.Enrollments.GetTableNoTracking().Where(e => e.UserId == userId);
        var courses = unitOfWork.Courses.GetTableNoTracking().AsQueryable();

        var FilterQuery = enrollments
            .Join(courses, e => e.CourseId, c => c.Id, (e, c) =>
            new GetUserEnrollmentsPaginatedListResponse { UserId = userId, CourseId = c.Id, Title = c.Title, Thumbnail = c.Thumbnail!, InstructorName = c.Instructor.FullName, EnrolledAt = e.EnrolledAt });

        var PaginatedList = await FilterQuery.ToPaginatedListAsync(request.PageNumber, request.PageSize);
        return PaginatedList;
    }
}
