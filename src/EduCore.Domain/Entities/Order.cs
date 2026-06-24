using EduCore.Domain.Entities.Identity;

namespace EduCore.Domain.Entities;

public class Order : DatedEntity
{
    public Order()
    {
        OrderItems = new HashSet<OrderItem>();
    }
    public Guid CustomerId { get; set; }
    public User Customer { get; set; }
    public decimal TotalBaseAmount { get; set; }
    public decimal TotalDiscountAmount { get; set; }
    public decimal TotalAmount { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
    public Enrollment Enrollment { get; set; }
}
