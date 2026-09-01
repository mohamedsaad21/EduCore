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

        var section = await unitOfWork.Sections.GetTableNoTracking()
            .Include(s => s.Course)
            .FirstOrDefaultAsync(s => s.Id == request.SectionId, cancellationToken);

        if (section is null)
            return Errors.SectionNotFound; // adjust to your Result API

        bool isEnrolled = await enrollmentService.CheckEnrollmentAsync(section.Course, user);
        if (!isEnrolled)
            return new List<GetContentListResponse>();

// keep this as IQueryable — do NOT ToListAsync it
        var courseProgress = unitOfWork.UserCourseProgresses.GetTableNoTracking()
            .Where(x => x.UserId == user.Id);

        var content = await unitOfWork.Contents.GetTableNoTracking()
            .Where(c => c.SectionId == request.SectionId)
            .GroupJoin(courseProgress,
                c => c.Id,
                p => p.ContentId,
                (c, progresses) => new { c, progresses })
            .SelectMany(
                x => x.progresses.DefaultIfEmpty(),
                (x, p) => new GetContentListResponse
                {
                    Id = x.c.Id,
                    Title = x.c.Title,
                    Duration = x.c.Duration,
                    Url = x.c.Url,
                    IsCompleted = p != null && p.IsCompleted,
                    SectionId = x.c.SectionId
                })
            .ToListAsync(cancellationToken);

        return content;
    }
}
