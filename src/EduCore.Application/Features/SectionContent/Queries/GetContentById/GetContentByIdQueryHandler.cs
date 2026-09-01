using AutoMapper;
using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Features.SectionContent.Queries.GetContentById;

public sealed class GetContentByIdQueryHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IEnrollmentService enrollmentService, IMapper mapper) : IRequestHandler<GetContentByIdQuery, Result<GetContentByIdResponse>>
{
    public async Task<Result<GetContentByIdResponse>> Handle(GetContentByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await currentUserService.GetCurrentUserAsync();
        var content = await unitOfWork.Contents.GetTableNoTracking().Include(c => c.Section).ThenInclude(s => s.Course)
            .FirstOrDefaultAsync(c => c.Id == request.Id);
        var course = content.Section.Course;
        bool isEnrolled = await enrollmentService.CheckEnrollmentAsync(course, user);
        if (!isEnrolled)
            return Errors.NotEnrolledInCourse;

        var contentMapper = mapper.Map<GetContentByIdResponse>(content);
        return contentMapper;
    }
}
