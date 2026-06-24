using EduCore.Application.Features.Category.Commands.EditCategory;
using EduCore.Domain.Entities;

namespace EduCore.Core.Mapping.Category;

public partial class CategoryProfile
{
    public void EditCategoryCommandMapping()
    {
        CreateMap<EditCategoryCommand, CourseCategory>();
    }
}
