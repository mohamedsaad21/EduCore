using EduCore.Application.Features.ShoppingCart.Queries.GetCartByCustomerId.Responses;
using EduCore.Domain.Entities;

namespace EduCore.Core.Mapping.ShoppingCart;

public partial class ShoppingCartProfile
{
    public void GetCartByCustomerIdMapping()
    {
        CreateMap<BasketItem, GetCartItemResponse>()
            .ForMember(dest => dest.CourseTitle, opt => opt.MapFrom(src => src.Course.Title));
        CreateMap<Basket, GetCartByCustomerIdResponse>()
            .ForMember(dest => dest.TotalBasePrice, opt => opt.MapFrom(src => src.BasketItems.Sum(x => x.BasePrice)))
            .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.BasketItems.Sum(x => x.TotalPrice)))
            .ForMember(dest => dest.TotalDiscountPrice, opt => opt.MapFrom(src => src.BasketItems.Sum(x => x.Discount)));
    }
}
