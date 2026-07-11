using EduCore.Application.Common.DTOs.Payment;

namespace EduCore.Application.Abstracts;

public interface IPaymentService
{
    Task<PaymentIntentResponseDto> CreateOrUpdatePaymentIntentAsync(Guid basketId);
    Task UpdateOrderPaymentStatusAsync(string request, string stripeHeader);
}
