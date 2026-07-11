using AutoMapper;

namespace EduCore.Core.Mapping.Category
{
    public partial class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            AddCategoryCommandMapping();
            EditCategoryCommandMapping();
            GetCategoriesListMapping();
            GetCategoryByIdMapping();
        }
    }
}
