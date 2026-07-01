using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Application.Wrappers;
using EduCore.Core.Resources;
using EduCore.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Localization;
using System.Linq.Expressions;

namespace EduCore.Core.Features.Courses.Queries.GetCoursePaginatedList;

public sealed class GetCoursePaginatedListQueryHandler(IStringLocalizer<SharedResources> stringLocalizer, ICourseService courseService) : IRequestHandler<GetCoursePaginatedListQuery, Result<PaginatedResult<GetCoursePaginatedListResponse>>>
{
    public async Task<Result<PaginatedResult<GetCoursePaginatedListResponse>>> Handle(GetCoursePaginatedListQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<Course, GetCoursePaginatedListResponse>> expression =
    e => new GetCoursePaginatedListResponse(e.Id, e.Title, e.Description, e.ThumbnailUrl, e.Price, e.Status.ToString(), e.CreatedAt, e.CategoryId, e.Instructor.FullName, e.Instructor.ProfilePictureUrl, e.AverageRating, e.RatingCount, e.NoOfStudents, e.UpdatedAt, e.Category);
        var FilterQuery = courseService.GetPaginatedListAsync(request.OrderBy, request.Search);
        var paginatedList = await FilterQuery.Select(expression).ToPaginatedListAsync(request.pageNumber, request.pageSize);
        return paginatedList;
    }
}
