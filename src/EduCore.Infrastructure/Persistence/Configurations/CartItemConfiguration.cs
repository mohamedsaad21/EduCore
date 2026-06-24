using EduCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduCore.Infrastructure.Persistence.Configurations;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.HasKey(item => item.Id);
        builder.Property(item => item.BasePrice).IsRequired();
        builder.Property(item => item.Discount).IsRequired();
        builder.Property(item => item.TotalPrice).IsRequired();

        builder.HasOne(item => item.Course).WithMany().HasForeignKey(item => item.CourseId).OnDelete(DeleteBehavior.NoAction);
    }
}
