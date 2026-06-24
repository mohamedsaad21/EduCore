using EduCore.Application.Bases;
using EduCore.Application.Features.ShoppingCart.Queries.GetCartByCustomerId.Responses;
using MediatR;

namespace EduCore.Application.Features.Payment.Commands.CreateOrUpdatePaymentIntent;

public sealed record CreateOrUpdatePaymentIntentCommand(Guid CartId) : IRequest<Result<GetCartByCustomerIdResponse>>;