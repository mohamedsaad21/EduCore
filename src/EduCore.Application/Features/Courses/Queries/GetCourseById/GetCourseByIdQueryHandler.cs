using AutoMapper;
using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.Courses.Queries.GetCourseById;

public sealed class GetCourseByIdQueryHandler(ICourseService courseService, IMapper mapper) : IRequestHandler<GetCourseByIdQuery, Result<GetCourseByIdResponse>>
{
    public async Task<Result<GetCourseByIdResponse>> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
    {
        var course = await courseService.GetByIdAsync(request.Id);
        if (course == null) return Errors.CourseNotFound; ;
        var courseMapper = mapper.Map<GetCourseByIdResponse>(course);
        return courseMapper;
    }
}
