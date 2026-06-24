using EduCore.Application.Bases;
using EduCore.Application.Features.ShoppingCart.Queries.GetCartByCustomerId.Responses;
using MediatR;

namespace EduCore.Application.Features.ShoppingCart.Queries.GetCartByCustomerId;

public sealed record GetCartByCustomerIdQuery() : IRequest<Result<GetCartByCustomerIdResponse>>;