using EduCore.Core.Features.Courses.Commands.AddCourse;
using EduCore.Domain.Entities;

namespace EduCore.Core.Mapping.Courses;

public partial class CourseProfile
{
    public void CreateCourseCommandMapping()
    {
        CreateMap<AddCourseCommand, Course>()
            .ForMember(dest => dest.Thumbnail, opt => opt.Ignore());
    }
}
