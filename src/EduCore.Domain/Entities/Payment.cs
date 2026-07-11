using EduCore.Domain.Enums;

namespace EduCore.Domain.Entities;

public class Payment : BaseEntity
{
    public Guid BasketId { get; set; }
    public Basket Basket { get; set; }
    public string? PaymentIntentId { get; set; }
    public string? ClientSecret { get; set; }
    public PaymentStatus Status { get; set; }
    public decimal Amount { get; set; }
    public string? FailureReason { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
