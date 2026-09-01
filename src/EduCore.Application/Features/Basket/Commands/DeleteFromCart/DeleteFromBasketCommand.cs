using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.Basket.Commands.DeleteFromBasket;

public sealed record DeleteFromBasketCommand(Guid CourseId) : IRequest<Result>;