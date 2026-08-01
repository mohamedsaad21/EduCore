namespace EduCore.Application.Features.Basket.Queries.GetBasketByCustomerId.Responses
{
    public class GetBasketByCustomerIdResponse
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public ICollection<GetBasketItemResponse> BasketItems { get; set; }
        public decimal TotalBasePrice { get; set; }
        public decimal TotalDiscountPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? PaymentIntentId { get; set; }
        public string? ClientSecret { get; set; }
    }
}
