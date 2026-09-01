using EduCore.Core.Features.Courses.Queries.GetCoursesByInstructorIdPaginatedList;
using EduCore.Domain.Entities;

namespace EduCore.Application.Mapping.Courses;

public partial class CourseProfile
{
    public void CourseDomainListToGetCoursesByInstructorIdPaginatedListResponseMapping()
    {
        CreateMap<Course, GetCoursesByInstructorIdPaginatedListResponse>()
            .ForMember(dest => dest.InstructorId, opt => opt.MapFrom(src => src.Instructor.Id))
            .ForMember(dest => dest.InstructorName, opt => opt.MapFrom(src => src.Instructor.FullName))
            .ForMember(dest => dest.InstructorProfilePictureUrl, opt => opt.MapFrom(src => src.Instructor.ProfilePictureUrl));
    }
}
