using EduCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduCore.Infrastructure.Persistence.Configurations;

public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
{
    public void Configure(EntityTypeBuilder<Feedback> builder)
    {
        builder.HasKey(f => f.Id);
        builder.Property(f => f.Rating).IsRequired();
        builder.Property(f => f.Comment).IsRequired(false);
        builder.HasOne(f => f.Course).WithMany(c => c.Feedbacks).HasForeignKey(f => f.CourseId).OnDelete(DeleteBehavior.NoAction);
    }
}
