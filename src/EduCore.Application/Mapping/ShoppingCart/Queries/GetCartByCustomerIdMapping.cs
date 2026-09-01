using EduCore.Application.Features.Basket.Queries.GetBasketByCustomerId.Responses;
using EduCore.Domain.Entities;

namespace EduCore.Core.Mapping.ShoppingCart;

public partial class ShoppingCartProfile
{
    public void GetCartByCustomerIdMapping()
    {
        CreateMap<BasketItem, GetBasketItemResponse>()
            .ForMember(dest => dest.CourseTitle, opt => opt.MapFrom(src => src.Course.Title))
            .ForMember(dest => dest.CourseThumbnailUrl, opt => opt.MapFrom(src => src.Course.ThumbnailUrl))
            .ForMember(dest => dest.AverageRating, opt => opt.MapFrom(src => src.Course.AverageRating))
            .ForMember(dest => dest.TotalHours, opt => opt.MapFrom(src => src.Course.TotalHours))
            .ForMember(dest => dest.NoOfLectures, opt => opt.MapFrom(src => src.Course.NoOfLectures))
            .ForMember(dest => dest.InstructorName, opt => opt.MapFrom(src => src.Course.Instructor.FullName))
            .ForMember(dest => dest.InstructorProfilePictureUrl, opt => opt.MapFrom(src => src.Course.Instructor.ProfilePictureUrl))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Course.Category.Localize(src.Course.Category.NameAr, src.Course.Category.NameEn)));
        
        CreateMap<Basket, GetBasketByCustomerIdResponse>()
            .ForMember(dest => dest.TotalBasePrice, opt => opt.MapFrom(src => src.BasketItems.Sum(x => x.BasePrice)))
            .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.BasketItems.Sum(x => x.TotalPrice)))
            .ForMember(dest => dest.TotalDiscountPrice, opt => opt.MapFrom(src => src.BasketItems.Sum(x => x.Discount)));
    }
}
