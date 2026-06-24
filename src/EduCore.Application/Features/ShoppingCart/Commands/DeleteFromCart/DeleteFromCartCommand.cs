using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.ShoppingCart.Commands.DeleteFromCart;

public sealed record DeleteFromCartCommand(Guid CourseId) : IRequest<Result>;