using AutoMapper;
using EduCore.Application.Bases;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Features.Sections.Queries.GetCourseSectionsList;

public sealed class GetCourseSectionsListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetCourseSectionsListQuery, Result<List<GetCourseSectionsListResponse>>>
{
    public async Task<Result<List<GetCourseSectionsListResponse>>> Handle(GetCourseSectionsListQuery request, CancellationToken cancellationToken)
    {
        var course = await unitOfWork.Courses.GetTableNoTracking().FirstOrDefaultAsync(x => x.Id == request.CourseId);

        if (course == null)
            return Errors.CourseNotFound;

        var sections = await unitOfWork.Sections.GetTableNoTracking().Where(x => x.CourseId == course.Id).ToListAsync();
        var result = mapper.Map<List<GetCourseSectionsListResponse>>(sections);
        return result;
    }
}
