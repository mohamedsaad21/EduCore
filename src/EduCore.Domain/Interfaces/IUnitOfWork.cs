using EduCore.Domain.Entities;

namespace EduCore.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Basket> Baskets { get; }
    IGenericRepository<CourseCategory> Categories { get; }
    IGenericRepository<Course> Courses { get; }
    IGenericRepository<Payment> Payments { get; }
    IGenericRepository<Enrollment> Enrollments { get; }
    IGenericRepository<Feedback> Feedbacks { get; }
    IGenericRepository<Section> Sections { get; }
    IGenericRepository<SectionContent> Contents { get; }
    IGenericRepository<UserCourseProgress> UserCourseProgresses { get; }
    Task<int> SaveChangesAsync();
}
