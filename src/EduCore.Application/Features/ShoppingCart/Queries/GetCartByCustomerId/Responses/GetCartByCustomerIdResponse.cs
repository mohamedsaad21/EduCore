namespace EduCore.Application.Features.ShoppingCart.Queries.GetCartByCustomerId.Responses
{
    public class GetCartByCustomerIdResponse
    {
        public Guid Id { get; set; }
        public string CustomerId { get; set; }
        public ICollection<GetCartItemResponse> CartItems { get; set; }
        public decimal TotalBasePrice { get; set; }
        public decimal TotalDiscountPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? PaymentIntentId { get; set; }
        public string? ClientSecret { get; set; }
    }
}
