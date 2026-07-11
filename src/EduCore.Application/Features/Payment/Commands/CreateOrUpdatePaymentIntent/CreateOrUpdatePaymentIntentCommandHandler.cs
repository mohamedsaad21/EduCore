using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Application.Common.DTOs.Payment;
using MediatR;

namespace EduCore.Application.Features.Payment.Commands.CreateOrUpdatePaymentIntent;

public class CreateOrUpdatePaymentIntentCommandHandler(IPaymentService paymentService) : IRequestHandler<CreateOrUpdatePaymentIntentCommand, Result<PaymentIntentResponseDto>>
{
    public async Task<Result<PaymentIntentResponseDto>> Handle(CreateOrUpdatePaymentIntentCommand request, CancellationToken cancellationToken)
    {
        return await paymentService.CreateOrUpdatePaymentIntentAsync(request.BasketId);
    }
}