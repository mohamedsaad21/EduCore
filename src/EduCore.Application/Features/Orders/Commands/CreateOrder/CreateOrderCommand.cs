using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.Orders.Commands.CreateOrder;

public sealed record CreateOrderCommand
    (
        Guid CartId
    ) : IRequest<Result<Guid>>;