namespace EduCore.Application.Common.DTOs.Order;

public class GetOrderItemResponse
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid CourseId { get; set; }
    public decimal BasePrice { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
