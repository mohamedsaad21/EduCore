using EduCore.Application.Features.SectionContent.Queries.GetContentPreviewList;
using EduCore.Domain.Entities;

namespace EduCore.Application.Mapping.Content;

public partial class ContentProfile
{
    public void GetContentPreviewListMapping()
    {
        CreateMap<SectionContent, GetContentPreviewListResponse>();
    }
}
