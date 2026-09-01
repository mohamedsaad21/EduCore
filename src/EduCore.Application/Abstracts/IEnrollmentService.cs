using EduCore.Domain.Entities;
using EduCore.Domain.Entities.Identity;

namespace EduCore.Application.Abstracts;

public interface IEnrollmentService
{
    Task CreateEnrollemnt(Guid UserId, Guid CourseId);
    Task<List<Enrollment>> GetUserEnrollmentsListAsync();
    Task<bool> CheckEnrollmentAsync(Course course, User user);
}
