using EduCore.Application.Features.Category.Queries.GetCategoryById;
using EduCore.Domain.Entities;

namespace EduCore.Core.Mapping.Category;

public partial class CategoryProfile
{
    public void GetCategoryByIdMapping()
    {
        CreateMap<CourseCategory, GetCategoryByIdResponse>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));
    }
}
