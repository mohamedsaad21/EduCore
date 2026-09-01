using EduCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduCore.Infrastructure.Persistence.Configurations;

public class SectionConfigurations : IEntityTypeConfiguration<Section>
{
    public void Configure(EntityTypeBuilder<Section> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title).IsRequired().HasMaxLength(250);
        builder.HasIndex(x => new { x.CourseId, x.Order }).IsUnique();
        builder.HasIndex(x => new { x.CourseId, x.Title }).IsUnique();
    }
}
