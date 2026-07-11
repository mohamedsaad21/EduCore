using EduCore.Application.Features.Sections.Queries.GetCourseSectionsPaginatedList;
using EduCore.Domain.Entities;

namespace EduCore.Application.Mapping.Sections;

public partial class SectionProfile
{
    public void SectionDomainListToGetCourseSectionsPaginatedListResponseMapping()
    {
        CreateMap<Section, GetCourseSectionsPaginatedListResponse>();
    }
}
