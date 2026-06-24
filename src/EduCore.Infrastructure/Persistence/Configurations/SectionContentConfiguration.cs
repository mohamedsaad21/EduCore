using EduCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduCore.Infrastructure.Persistence.Configurations;

public class SectionContentConfiguration : IEntityTypeConfiguration<SectionContent>
{
    public void Configure(EntityTypeBuilder<SectionContent> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasMany(c => c.UserCourseProgress).WithOne(p => p.Content).HasForeignKey(c => c.ContentId).OnDelete(DeleteBehavior.NoAction);
    }
}
