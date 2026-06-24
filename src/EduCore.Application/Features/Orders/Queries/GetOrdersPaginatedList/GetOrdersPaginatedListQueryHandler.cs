using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Application.Common.DTOs.Order;
using EduCore.Application.Wrappers;
using EduCore.Core.Features.Orders.Queries.Models;
using EduCore.Domain.Entities;
using MediatR;
using System.Linq.Expressions;

namespace EduCore.Application.Features.Orders.Queries.GetOrdersPaginatedList;

public sealed class GetOrdersPaginatedListQueryHandler(IOrderService orderService, ICurrentUserService currentUserService) : IRequestHandler<GetOrdersPaginatedListQuery, Result<PaginatedResult<GetOrdersPaginatedListResponse>>>
{
    public async Task<Result<PaginatedResult<GetOrdersPaginatedListResponse>>> Handle(GetOrdersPaginatedListQuery request, CancellationToken cancellationToken)
    {
        var customerId = await currentUserService.GetCurrentUserId();
        Expression<Func<Order, GetOrdersPaginatedListResponse>> expression = e => new GetOrdersPaginatedListResponse
        {
            Id = e.Id,
            CustomerId = e.CustomerId,
            TotalBaseAmount = e.TotalBaseAmount,
            TotalDiscountAmount = e.TotalDiscountAmount,
            TotalAmount = e.TotalAmount,
            CreatedAt = e.CreatedAt,
            UpdatedAt = e.UpdatedAt,
            OrderItems = e.OrderItems.Select(item => new GetOrderItemResponse
            {
                Id = item.Id,
                CourseId = item.CourseId,
                BasePrice = item.BasePrice,
                Discount = item.Discount,
                TotalPrice = item.TotalPrice,
                OrderId = item.OrderId,
                CreatedAt = item.CreatedAt,
                UpdatedAt = item.UpdatedAt
            }).ToList()
        };
        var FilterQuery = orderService.GetAllPaginatedListAsync(customerId, request.OrderBy);
        var PaginatedList = await FilterQuery.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
        return PaginatedList;
    }
}
