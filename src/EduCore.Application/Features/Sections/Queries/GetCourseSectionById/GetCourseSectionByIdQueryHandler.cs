using AutoMapper;
using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.Sections.Queries.GetCourseSectionById;

public sealed class GetCourseSectionByIdQueryHandler(ISectionService sectionService, IMapper mapper) : IRequestHandler<GetCourseSectionByIdQuery, Result<GetCourseSectionByIdResponse>>
{
    public async Task<Result<GetCourseSectionByIdResponse>> Handle(GetCourseSectionByIdQuery request, CancellationToken cancellationToken)
    {
        var Section = await sectionService.GetByIdAsync(request.Id);
        if (Section == null) return Errors.SectionNotFound;
        var sectionMapper = mapper.Map<GetCourseSectionByIdResponse>(Section);
        return sectionMapper;
    }
}
