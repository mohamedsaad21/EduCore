using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.Basket.Commands.AddToBasket;

public sealed record AddToBasketCommand(Guid CourseId) : IRequest<Result>;