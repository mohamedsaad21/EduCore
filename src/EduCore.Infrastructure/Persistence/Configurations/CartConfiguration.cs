using EduCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduCore.Infrastructure.Persistence.Configurations;

public class CartConfiguration : IEntityTypeConfiguration<Basket>
{
    public void Configure(EntityTypeBuilder<Basket> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasOne(c => c.Customer).WithMany(u => u.Baskets).HasForeignKey(c => c.CustomerId);
        builder.HasMany(c => c.BasketItems).WithOne(item => item.Basket).HasForeignKey(item => item.CartId);
    }
}
