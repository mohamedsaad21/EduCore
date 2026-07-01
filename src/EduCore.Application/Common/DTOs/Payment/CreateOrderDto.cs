using System.ComponentModel.DataAnnotations;

namespace EduCore.Application.Common.DTOs.Payment;

public class CreateOrderDto
{
    [Required]
    public string CartId { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Payment method ID must be a positive integer")]
    public int PaymentMethodId { get; set; }
}