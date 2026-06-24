using EduCore.Application.Bases;
using EduCore.Application.Features.Orders.Queries.GetOrdersPaginatedList;
using EduCore.Application.Wrappers;
using EduCore.Domain.Enums;
using MediatR;

namespace EduCore.Core.Features.Orders.Queries.Models;

public sealed record GetOrdersPaginatedListQuery
    (
        int PageSize,
        int PageNumber,
        OrderOrderingEnum OrderBy
    ) : IRequest<Result<PaginatedResult<GetOrdersPaginatedListResponse>>>;
