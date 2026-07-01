using EduCore.Application.Features.Courses.Commands.EditCourse;
using EduCore.Domain.Entities;

namespace EduCore.Core.Mapping.Courses;

public partial class CourseProfile
{
    public void EditCourseCommandMapping()
    {
        CreateMap<EditCourseCommand, Course>()
            .ForMember(dest => dest.ThumbnailUrl, opt => opt.Ignore());
    }
}
