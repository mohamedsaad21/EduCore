using EduCore.Application.Bases;
using EduCore.Application.Wrappers;
using EduCore.Domain.Enums;
using MediatR;

namespace EduCore.Application.Features.ApplicationUser.Queries.GetUsersPaginatedList;

public sealed record GetUsersPaginatedListQuery
(
    int PageNumber,
    int PageSize,
    UserOrderingEnum OrderBy,
    string? Search
) : IRequest<Result<PaginatedResult<GetUsersPaginatedListResponse>>>;