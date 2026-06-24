using EduCore.Application.Common.DTOs.Order;

namespace EduCore.Application.Features.Orders.Queries.GetOrderById;

public class GetOrderByIdResponse
{
    public Guid Id { get; set; }
    public string CustomerId { get; set; }
    public decimal TotalBaseAmount { get; set; }
    public decimal TotalDiscountAmount { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public virtual ICollection<GetOrderItemResponse> OrderItems { get; set; }
}
