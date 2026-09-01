using AutoMapper;
using EduCore.Application.Bases;
using EduCore.Application.Features.SectionContent.Queries.GetContentList;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Features.SectionContent.Queries.GetContentPreviewList;

public class GetContentPreviewListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetContentPreviewListQuery, Result<List<GetContentPreviewListResponse>>>
{
    public async Task<Result<List<GetContentPreviewListResponse>>> Handle(GetContentPreviewListQuery request, CancellationToken cancellationToken)
    {
        var section = await unitOfWork.Sections.GetTableNoTracking().Include(s => s.Course).FirstOrDefaultAsync(s => s.Id == request.SectionId);
        var course = section.Course;
        var content = await unitOfWork.Contents.GetTableNoTracking().Where(c => c.SectionId == request.SectionId).ToListAsync();
        var contentMapper = mapper.Map<List<GetContentPreviewListResponse>>(content);
        return contentMapper;
    }
}