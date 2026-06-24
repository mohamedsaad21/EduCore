using EduCore.Core.Features.Category.Commands.Models;
using EduCore.Domain.Entities;

namespace EduCore.Core.Mapping.Category;

public partial class CategoryProfile
{
    public void AddCategoryCommandMapping()
    {
        CreateMap<AddCategoryCommand, CourseCategory>();
    }
}
