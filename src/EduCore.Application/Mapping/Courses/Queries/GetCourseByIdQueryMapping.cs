using EduCore.Application.Features.Courses.Queries.GetCourseById;
using EduCore.Domain.Entities;

namespace EduCore.Core.Mapping.Courses;

public partial class CourseProfile
{
    public void GetCourseByIdQueryMapping()
    {
        CreateMap<Course, GetCourseByIdResponse>()
            .ForMember(dest => dest.InstructorName, opt => opt.MapFrom(src => src.Instructor.FullName))
            .ForMember(dest => dest.InstructorProfilePictureUrl, opt => opt.MapFrom(src => src.Instructor.ProfilePictureUrl));
    }
}
