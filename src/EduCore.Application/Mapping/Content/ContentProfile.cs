using AutoMapper;

namespace EduCore.Application.Mapping.Content;

public partial class ContentProfile : Profile
{
    public ContentProfile()
    {
        GetContentListMapping();
        GetContentPreviewListMapping();
        GetContentByIdMapping();
    }
}
