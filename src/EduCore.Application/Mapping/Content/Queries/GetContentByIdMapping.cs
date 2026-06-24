using EduCore.Application.Features.SectionContent.Queries.GetContentById;
using EduCore.Domain.Entities;

namespace EduCore.Core.Mapping.Content;

public partial class ContentProfile
{
    public void GetContentByIdMapping()
    {
        CreateMap<SectionContent, GetContentByIdResponse>()
            .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => TimeSpan.FromSeconds(src.Duration)));
    }
}
