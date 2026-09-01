using AutoMapper;
using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Features.Sections.Queries.GetCourseSectionById;

public sealed class GetCourseSectionByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetCourseSectionByIdQuery, Result<GetCourseSectionByIdResponse>>
{
    public async Task<Result<GetCourseSectionByIdResponse>> Handle(GetCourseSectionByIdQuery request, CancellationToken cancellationToken)
    {
        var Section = await unitOfWork.Sections.GetTableNoTracking().Include(x => x.SectionContents)
            .FirstOrDefaultAsync(x => x.Id == request.Id);
        
        if (Section == null)
            return Errors.SectionNotFound;

        var sectionMapper = mapper.Map<GetCourseSectionByIdResponse>(Section);
        return sectionMapper;
    }
}
