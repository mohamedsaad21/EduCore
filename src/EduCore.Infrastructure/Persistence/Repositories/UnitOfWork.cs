using EduCore.Domain.Entities;
using EduCore.Domain.Interfaces;

namespace EduCore.Infrastructure.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;
    public IGenericRepository<Cart> Carts { get; private set; }
    public IGenericRepository<CourseCategory> Categories { get; private set; }
    public IGenericRepository<Course> Courses { get; private set; }
    public IGenericRepository<Enrollment> Enrollments { get; private set; }
    public IGenericRepository<Feedback> Feedbacks { get; private set; }
    public IGenericRepository<Order> Orders { get; private set; }
    public IGenericRepository<Section> Sections { get; private set; }
    public IGenericRepository<SectionContent> Contents { get; private set; }
    public IGenericRepository<UserCourseProgress> UserCourseProgresses { get; private set; }

    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        Carts = new GenericRepository<Cart>(dbContext);
        Categories = new GenericRepository<CourseCategory>(dbContext);
        Courses = new GenericRepository<Course>(dbContext);
        Enrollments = new GenericRepository<Enrollment>(dbContext);
        Feedbacks = new GenericRepository<Feedback>(dbContext);
        Orders = new GenericRepository<Order>(dbContext);
        Sections = new GenericRepository<Section>(dbContext);
        Contents = new GenericRepository<SectionContent>(dbContext);
        UserCourseProgresses = new GenericRepository<UserCourseProgress>(dbContext);
    }
    public void Dispose() => _dbContext.Dispose();
    public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();
}
