using AutoMapper;

namespace EduCore.Application.Mapping.Courses;

public partial class CourseProfile : Profile
{
    public CourseProfile()
    {
        CreateCourseCommandMapping();
        EditCourseCommandMapping();
        GetCourseByIdQueryMapping();
        CourseDomainListToGetCoursePaginatedListResponseMapping();
        CourseDomainListToGetCoursesByCategoryIdPaginatedListResponseMapping();
        CourseDomainListToGetCoursesByInstructorIdPaginatedListResponseMapping();
    }
}
