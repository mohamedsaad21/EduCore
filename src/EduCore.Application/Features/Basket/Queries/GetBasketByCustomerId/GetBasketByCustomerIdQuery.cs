using EduCore.Application.Bases;
using EduCore.Application.Features.Basket.Queries.GetBasketByCustomerId.Responses;
using MediatR;

namespace EduCore.Application.Features.Basket.Queries.GetBasketByCustomerId;

public sealed record GetBasketByCustomerIdQuery() : IRequest<Result<GetBasketByCustomerIdResponse>>;