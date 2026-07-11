using EduCore.Domain.Entities.Identity;

namespace EduCore.Domain.Entities;

public class Basket : DatedEntity
{
    public Basket()
    {
        BasketItems = new HashSet<BasketItem>();
    }
    public Guid CustomerId { get; set; }
    public User Customer { get; set; }
    public bool IsCheckedOut { get; set; }
    public ICollection<BasketItem> BasketItems { get; set; }
    public ICollection<Payment> Payments { get; set; }
}
