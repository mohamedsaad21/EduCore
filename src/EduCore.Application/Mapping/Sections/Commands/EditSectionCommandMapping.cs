using EduCore.Application.Features.Sections.Commands.EditSection;
using EduCore.Domain.Entities;

namespace EduCore.Application.Mapping.Sections;

public partial class SectionProfile
{
    public void EditSectionCommandMapping()
    {
        CreateMap<EditSectionCommand, Section>();
    }
}
