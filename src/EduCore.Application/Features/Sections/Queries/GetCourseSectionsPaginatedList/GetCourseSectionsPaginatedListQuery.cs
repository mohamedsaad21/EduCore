using EduCore.Application.Bases;
using EduCore.Application.Wrappers;
using EduCore.Domain.Enums;
using MediatR;

namespace EduCore.Application.Features.Sections.Queries.GetCourseSectionsPaginatedList;

public sealed record GetCourseSectionsPaginatedListQuery
    (
        Guid CourseId,
        int PageSize,
        int PageNumber,
        SectionOrderingEnum OrderBy,
        string? Search
    ) : IRequest<Result<PaginatedResult<GetCourseSectionsPaginatedListResponse>>>;