using EduCore.Application.Features.Sections.Queries.GetCourseSectionById;
using EduCore.Domain.Entities;

namespace EduCore.Core.Mapping.Sections;

public partial class SectionProfile
{
    public void GetCourseSectionByIdQueryMapping()
    {
        CreateMap<Section, GetCourseSectionByIdResponse>();
    }
}
