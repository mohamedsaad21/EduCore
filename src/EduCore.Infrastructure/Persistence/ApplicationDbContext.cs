using EduCore.Domain.Entities;
using EduCore.Domain.Entities.Identity;
using EduCore.Infrastructure.Persistence.Configurations;
using EntityFrameworkCore.EncryptColumn.Extension;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Infrastructure.Persistence;

public class ApplicationDbContext : IdentityDbContext<User, Role, Guid>
{
    private readonly IEncryptionProvider _encryptionProvider;
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        _encryptionProvider = new GenerateEncryptionProvider("02D08259E75F463A9D492B1FE4A22E3C");
    }

    public virtual DbSet<CourseCategory> CourseCategories { get; set; }
    public virtual DbSet<Course> Courses { get; set; }
    public virtual DbSet<Section> Sections { get; set; }
    public virtual DbSet<SectionContent> SectionContents { get; set; }
    public virtual DbSet<Cart> Carts { get; set; }
    public virtual DbSet<CartItem> CartItems { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<OrderItem> OrderItems { get; set; }
    public virtual DbSet<Enrollment> Enrollments { get; set; }
    public virtual DbSet<UserCourseProgress> UserCourseProgresses { get; set; }
    public virtual DbSet<Feedback> Feedbacks { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.UseEncryption(_encryptionProvider);

        builder.ApplyConfigurationsFromAssembly(typeof(CourseConfiguration).Assembly);
    }
}
