using AutoMapper;

namespace EduCore.Core.Mapping.Content
{
    public partial class ContentProfile : Profile
    {
        public ContentProfile()
        {
            GetContentListMapping();
            GetContentByIdMapping();
        }
    }
}
