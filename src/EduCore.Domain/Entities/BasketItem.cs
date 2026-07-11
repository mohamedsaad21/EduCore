namespace EduCore.Domain.Entities;

public class BasketItem : DatedEntity
{
    public Guid CartId { get; set; }
    public Basket Basket { get; set; }
    public Guid CourseId { get; set; }
    public Course Course { get; set; }
    public decimal BasePrice { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalPrice { get; set; }
}
