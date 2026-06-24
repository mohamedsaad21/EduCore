using EduCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduCore.Infrastructure.Persistence.Configurations;

public class OrderConfigurations : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(o => o.TotalBaseAmount).IsRequired();
        builder.Property(o => o.TotalDiscountAmount).IsRequired();
        builder.Property(o => o.TotalAmount).IsRequired();

        builder.HasOne(o => o.Customer).WithMany(c => c.Orders).HasForeignKey(o => o.CustomerId);
        builder.HasMany(o => o.OrderItems).WithOne(c => c.Order).HasForeignKey(o => o.OrderId);
        builder.HasOne(o => o.Enrollment).WithOne(e => e.Order).HasForeignKey<Enrollment>(e => e.OrderId);

    }
}
