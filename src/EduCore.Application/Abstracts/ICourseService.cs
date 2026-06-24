using EduCore.Domain.Entities;
using EduCore.Domain.Enums;

namespace EduCore.Application.Abstracts;

public interface ICourseService
{
    IQueryable<Course> GetPaginatedListAsync(CourseOrderingEnum orderBy, string? Search);
    IQueryable<Course> GetPaginatedListByCategoryIdAsync(Guid CategoryId, CourseOrderingEnum orderBy, string? Search);
    IQueryable<Course> GetPaginatedListByInstructorIdAsync(Guid InstructorId, CourseOrderingEnum orderBy, string? Search);
    Task<Course> GetByIdAsync(Guid Id);
}
