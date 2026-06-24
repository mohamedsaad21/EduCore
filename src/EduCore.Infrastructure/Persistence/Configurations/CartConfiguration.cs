using EduCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduCore.Infrastructure.Persistence.Configurations;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasOne(c => c.Customer).WithMany(u => u.Carts).HasForeignKey(c => c.CustomerId);
        builder.HasMany(c => c.CartItems).WithOne(item => item.Cart).HasForeignKey(item => item.CartId);
    }
}
