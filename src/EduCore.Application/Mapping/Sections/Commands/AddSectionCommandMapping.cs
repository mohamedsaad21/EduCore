using EduCore.Application.Features.Sections.Commands.AddSection;
using EduCore.Domain.Entities;

namespace EduCore.Application.Mapping.Sections;

public partial class SectionProfile
{
    public void AddSectionCommandMapping()
    {
        CreateMap<AddSectionCommand, Section>();
    }
}
