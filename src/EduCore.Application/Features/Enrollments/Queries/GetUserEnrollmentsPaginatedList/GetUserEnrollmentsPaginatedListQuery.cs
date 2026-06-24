using EduCore.Application.Bases;
using EduCore.Application.Wrappers;
using EduCore.Domain.Enums;
using EduCore.Domain.Results;
using MediatR;

namespace EduCore.Application.Features.Enrollments.Queries.GetUserEnrollmentsPaginatedList;

public sealed record GetUserEnrollmentsPaginatedListQuery
    (
        int PageNumber,
        int PageSize,
        UserEnrollmentsOrdering OrderBy,
        string? Search
    ) : IRequest<Result<PaginatedResult<GetUserEnrollmentsPaginatedListResponse>>>;