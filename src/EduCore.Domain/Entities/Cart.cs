using EduCore.Domain.Entities.Identity;

namespace EduCore.Domain.Entities;

public class Cart : DatedEntity
{
    public Cart()
    {
        CartItems = new HashSet<CartItem>();
    }
    public Guid CustomerId { get; set; }
    public User Customer { get; set; }
    public bool IsCheckedOut { get; set; }
    public string? PaymentIntentId { get; set; }
    public string? ClientSecret { get; set; }
    public ICollection<CartItem> CartItems { get; set; }
}
