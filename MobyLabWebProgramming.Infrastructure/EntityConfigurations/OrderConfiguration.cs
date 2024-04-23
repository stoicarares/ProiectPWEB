using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Infrastructure.EntityConfigurations
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(o => o.Id).IsRequired();
            builder.HasKey(o => o.Id);
            builder.Property(o => o.PaymentMethod).IsRequired();
            builder.Property(o => o.ShippingMethod).IsRequired();
            builder.HasOne(o => o.ShoppingCart).WithOne().HasForeignKey<Order>(o => o.ShoppingCartId).IsRequired();
        }
    }
}
