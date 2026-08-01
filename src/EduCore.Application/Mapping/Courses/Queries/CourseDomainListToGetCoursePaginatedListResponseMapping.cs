using EduCore.Core.Features.Courses.Queries.GetCoursePaginatedList;
using EduCore.Domain.Entities;

namespace EduCore.Application.Mapping.Courses;

public partial class CourseProfile
{
    public void CourseDomainListToGetCoursePaginatedListResponseMapping()
    {
        CreateMap<Course, GetCoursePaginatedListResponse>()
            .ForMember(dest => dest.InstructorId, opt => opt.MapFrom(src => src.Instructor.Id))
            .ForMember(dest => dest.InstructorName, opt => opt.MapFrom(src => src.Instructor.FullName))
            .ForMember(dest => dest.InstructorProfilePictureUrl, opt => opt.MapFrom(src => src.Instructor.ProfilePictureUrl));
        CreateMap<CourseCategory, CategoryResponse>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));
    }
}
