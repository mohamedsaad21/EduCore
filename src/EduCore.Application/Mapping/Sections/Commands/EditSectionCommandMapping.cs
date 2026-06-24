using EduCore.Application.Features.Sections.Commands.EditSection;
using EduCore.Domain.Entities;

namespace EduCore.Core.Mapping.Sections;

public partial class SectionProfile
{
    public void EditSectionCommandMapping()
    {
        CreateMap<EditSectionCommand, Section>();
    }
}
