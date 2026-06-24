using EduCore.Application.Features.Category.Queries.GetCategoriesList;
using EduCore.Domain.Entities;

namespace EduCore.Core.Mapping.Category;

public partial class CategoryProfile
{
    public void GetCategoriesListMapping()
    {
        CreateMap<CourseCategory, GetCategoriesListResponse>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));
    }
}
