using AutoMapper;

namespace EduCore.Application.Mapping.Sections;

public partial class SectionProfile : Profile
{
    public SectionProfile()
    {
        AddSectionCommandMapping();
        EditSectionCommandMapping();
        GetCourseSectionByIdQueryMapping();
        SectionDomainListToGetCourseSectionsPaginatedListResponseMapping();
        SectionDomainListToGetCourseSectionsListResponseMapping();
    }
}
