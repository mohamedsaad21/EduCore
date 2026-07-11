using AutoMapper;
using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Features.SectionContent.Queries.GetContentList;

public sealed class GetContentListQueryHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IEnrollmentService enrollmentService, IMapper mapper) : IRequestHandler<GetContentListQuery, Result<List<GetContentListResponse>>>
{
    public async Task<Result<List<GetContentListResponse>>> Handle(GetContentListQuery request, CancellationToken cancellationToken)
    {
        var user = await currentUserService.GetCurrentUserAsync();
        var section = await unitOfWork.Sections.GetTableNoTracking().Include(s => s.Course).FirstOrDefaultAsync(s => s.Id == request.SectionId);
        var course = section.Course;
        bool isEnrolled = await enrollmentService.CheckEnrollmentAsync(course, user);
        if (!isEnrolled)
            return Errors.NotEnrolledInCourse;

        var content = await unitOfWork.Contents.GetTableNoTracking().Where(c => c.SectionId == request.SectionId).ToListAsync();
        var contentMapper = mapper.Map<List<GetContentListResponse>>(content);
        return contentMapper;
    }
}
