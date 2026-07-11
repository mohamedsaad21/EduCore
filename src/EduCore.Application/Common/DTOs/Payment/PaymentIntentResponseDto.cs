namespace EduCore.Application.Common.DTOs.Payment;

public class PaymentIntentResponseDto
{
    public string ClientSecret { get; set; }
    public decimal Amount { get; set; }
}
