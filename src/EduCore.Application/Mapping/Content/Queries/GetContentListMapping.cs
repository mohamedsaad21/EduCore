using EduCore.Application.Features.SectionContent.Queries.GetContentList;
using EduCore.Domain.Entities;

namespace EduCore.Application.Mapping.Content;

public partial class ContentProfile
{
    public void GetContentListMapping()
    {
        CreateMap<SectionContent, GetContentListResponse>();
    }
}
