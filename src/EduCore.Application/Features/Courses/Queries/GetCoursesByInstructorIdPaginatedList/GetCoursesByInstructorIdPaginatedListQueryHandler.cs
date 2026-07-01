using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Application.Wrappers;
using EduCore.Domain.Entities;
using EduCore.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EduCore.Core.Features.Courses.Queries.GetCoursesByInstructorIdPaginatedList;

public sealed class GetCoursesByInstructorIdPaginatedListQueryHandler(UserManager<User> userManager, ICourseService courseService) : IRequestHandler<GetCoursesByInstructorIdPaginatedListQuery, Result<PaginatedResult<GetCoursesByInstructorIdPaginatedListResponse>>>
{
    public async Task<Result<PaginatedResult<GetCoursesByInstructorIdPaginatedListResponse>>> Handle(GetCoursesByInstructorIdPaginatedListQuery request, CancellationToken cancellationToken)
    {
        var instructor = await userManager.Users.FirstOrDefaultAsync(x => x.Id == request.InstructorId);

        if (instructor == null)
            return Errors.InstructorNotFound;

        Expression<Func<Course, GetCoursesByInstructorIdPaginatedListResponse>> expression =
e => new GetCoursesByInstructorIdPaginatedListResponse(e.Id, e.Title, e.Description, e.ThumbnailUrl, e.Price, e.Status.ToString(), e.CreatedAt, e.CategoryId, e.Instructor.FullName, e.Instructor.ProfilePictureUrl, e.AverageRating, e.RatingCount, e.NoOfStudents, e.UpdatedAt, e.Category);
        var FilterQuery = courseService.GetPaginatedListByInstructorIdAsync(request.InstructorId, request.OrderBy, request.Search);
        var paginatedList = await FilterQuery.Select(expression).ToPaginatedListAsync(request.pageNumber, request.pageSize);
        return paginatedList;
    }
}