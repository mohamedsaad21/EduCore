using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.ShoppingCart.Commands.AddToCart;

public sealed record AddToCartCommand(Guid CourseId) : IRequest<Result>;