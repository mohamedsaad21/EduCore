using EduCore.Application.Bases;
using EduCore.Application.Wrappers;
using EduCore.Domain.Enums;
using MediatR;

namespace EduCore.Core.Features.Courses.Queries.GetCoursePaginatedList;

public sealed record GetCoursePaginatedListQuery
    (
        int pageSize,
        int pageNumber,
        CourseOrderingEnum OrderBy,
        string? Search
    )
    : IRequest<Result<PaginatedResult<GetCoursePaginatedListResponse>>>;
