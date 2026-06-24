using EduCore.Domain.Entities;
using EduCore.Domain.Entities.Identity;

namespace EduCore.Application.Abstracts;

public interface IEnrollmentService
{
    Task<List<Enrollment>> GetUserEnrollmentsListAsync();
    Task<bool> CheckEnrollmentAsync(Course course, User user);
}
