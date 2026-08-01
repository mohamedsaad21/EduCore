namespace EduCore.Application.Features.Basket.Queries.GetBasketByCustomerId.Responses;

public class GetBasketItemResponse
{
    public Guid Id { get; set; }
    public Guid CartId { get; set; }
    public Guid CourseId { get; set; }
    public string CourseTitle { get; set; }
    public decimal BasePrice { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
