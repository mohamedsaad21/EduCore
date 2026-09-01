using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.Basket.Commands.ClearBasket;

public sealed record ClearBasketCommand : IRequest<Result>;