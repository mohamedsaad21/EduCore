using EduCore.Application.Bases;
using EduCore.Application.Common.DTOs.Payment;
using MediatR;

namespace EduCore.Application.Features.Payment.Commands.CreateOrUpdatePaymentIntent;

public sealed record CreateOrUpdatePaymentIntentCommand
    (
        Guid BasketId
    ) : IRequest<Result<PaymentIntentResponseDto>>;