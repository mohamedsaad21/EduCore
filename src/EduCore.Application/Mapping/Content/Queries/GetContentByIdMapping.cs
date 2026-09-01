using EduCore.Application.Features.SectionContent.Queries.GetContentById;
using EduCore.Domain.Entities;

namespace EduCore.Application.Mapping.Content;

public partial class ContentProfile
{
    public void GetContentByIdMapping()
    {
        CreateMap<SectionContent, GetContentByIdResponse>();
    }
}
