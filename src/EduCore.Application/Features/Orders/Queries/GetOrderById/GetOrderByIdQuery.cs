using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.Orders.Queries.GetOrderById;

public sealed record GetOrderByIdQuery(Guid Id) : IRequest<Result<GetOrderByIdResponse>>;