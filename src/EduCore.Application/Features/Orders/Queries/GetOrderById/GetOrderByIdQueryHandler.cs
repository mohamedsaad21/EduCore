using AutoMapper;
using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.Orders.Queries.GetOrderById;

public sealed class GetOrderByIdQueryHandler(IOrderService orderService, IMapper mapper) : IRequestHandler<GetOrderByIdQuery, Result<GetOrderByIdResponse>>
{
    public async Task<Result<GetOrderByIdResponse>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await orderService.GetByIdAsync(request.Id);
        if (order == null) return Errors.OrderNotFound;
        var orderMapper = mapper.Map<GetOrderByIdResponse>(order);
        return orderMapper;
    }
}
