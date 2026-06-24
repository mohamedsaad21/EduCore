using AutoMapper;

namespace EduCore.Core.Mapping.Sections
{
    public partial class SectionProfile : Profile
    {
        public SectionProfile()
        {
            AddSectionCommandMapping();
            EditSectionCommandMapping();
            GetCourseSectionByIdQueryMapping();
        }
    }
}
