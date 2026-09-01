using EduCore.Application.Features.Sections.Queries.GetCourseSectionsList;
using EduCore.Domain.Entities;

namespace EduCore.Application.Mapping.Sections;

public partial class SectionProfile
{
    public void SectionDomainListToGetCourseSectionsListResponseMapping()
    {
        CreateMap<Section, GetCourseSectionsListResponse>();
    }
}
