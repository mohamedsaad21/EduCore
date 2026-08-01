using EduCore.Application.Features.Basket.Queries.GetBasketByCustomerId.Responses;
using EduCore.Domain.Entities;

namespace EduCore.Core.Mapping.ShoppingCart;

public partial class ShoppingCartProfile
{
    public void GetCartByCustomerIdMapping()
    {
        CreateMap<BasketItem, GetBasketItemResponse>()
            .ForMember(dest => dest.CourseTitle, opt => opt.MapFrom(src => src.Course.Title));
        CreateMap<Basket, GetBasketByCustomerIdResponse>()
            .ForMember(dest => dest.TotalBasePrice, opt => opt.MapFrom(src => src.BasketItems.Sum(x => x.BasePrice)))
            .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.BasketItems.Sum(x => x.TotalPrice)))
            .ForMember(dest => dest.TotalDiscountPrice, opt => opt.MapFrom(src => src.BasketItems.Sum(x => x.Discount)));
    }
}
