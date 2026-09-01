using EduCore.Application.Bases;
using EduCore.Application.Wrappers;
using EduCore.Domain.Enums;
using MediatR;

namespace EduCore.Core.Features.Courses.Queries.GetCoursesByInstructorIdPaginatedList;

public sealed record GetCoursesByInstructorIdPaginatedListQuery(
        Guid InstructorId,
        int pageSize,
        int pageNumber,
        CourseOrderingEnum OrderBy,
        string? Search
    )
    : IRequest<Result<PaginatedResult<GetCoursesByInstructorIdPaginatedListResponse>>>;
