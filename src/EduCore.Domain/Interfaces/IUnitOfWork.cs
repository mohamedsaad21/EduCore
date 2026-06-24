using EduCore.Domain.Entities;

namespace EduCore.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Cart> Carts { get; }
    IGenericRepository<CourseCategory> Categories { get; }
    IGenericRepository<Course> Courses { get; }
    IGenericRepository<Enrollment> Enrollments { get; }
    IGenericRepository<Feedback> Feedbacks { get; }
    IGenericRepository<Order> Orders { get; }
    IGenericRepository<Section> Sections { get; }
    IGenericRepository<SectionContent> Contents { get; }
    IGenericRepository<UserCourseProgress> UserCourseProgresses { get; }
    Task<int> SaveChangesAsync();
}
