using AutoMapper;

namespace EduCore.Core.Mapping.Courses
{
    public partial class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateCourseCommandMapping();
            EditCourseCommandMapping();
            GetCourseByIdQueryMapping();
        }
    }
}
