using EduCore.Domain.Entities;

namespace EduCore.Application.Abstracts;

public interface ICourseProgressService
{
    Task<bool> IsCompletedFullCourse(Course Course);
}
