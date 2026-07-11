using EduCore.Application.Bases;
using EduCore.Application.Wrappers;
using MediatR;

namespace EduCore.Application.Features.Category.Queries.GetCategoriesList;

public sealed record GetCategoriesPaginatedListQuery
    (
        int PageNumber,
        int PageSize,
        string? Search
    ) : IRequest<Result<PaginatedResult<GetCategoriesPaginatedListResponse>>>;