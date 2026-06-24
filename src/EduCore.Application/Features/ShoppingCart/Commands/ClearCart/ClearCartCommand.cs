using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.ShoppingCart.Commands.ClearCart;

public sealed record ClearCartCommand : IRequest<Result>;