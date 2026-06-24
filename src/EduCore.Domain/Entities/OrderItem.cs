namespace EduCore.Domain.Entities;

public class OrderItem : DatedEntity
{
    public Guid OrderId { get; set; }
    public Order Order { get; set; }
    public Guid CourseId { get; set; }
    public Course Course { get; set; }
    public decimal BasePrice { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalPrice { get; set; }
}
