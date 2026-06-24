using EduCore.Application.Bases;
using EduCore.Application.Wrappers;
using EduCore.Domain.Enums;
using MediatR;

namespace EduCore.Core.Features.Courses.Queries.GetCoursesByCategoryIdPaginatedList;

public sealed record GetCoursesByCategoryIdPaginatedListQuery
    (
        Guid CategoryId,
        int pageSize,
        int pageNumber,
        CourseOrderingEnum OrderBy,
        string? Search
    )
    : IRequest<Result<PaginatedResult<GetCoursesByCategoryIdPaginatedListResponse>>>;
