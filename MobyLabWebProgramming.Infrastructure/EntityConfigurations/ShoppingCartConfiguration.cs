using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Infrastructure.EntityConfigurations
{
    public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.Property(sc => sc.Id).IsRequired();
            builder.HasKey(sc => sc.Id);
            builder.Property(sc => sc.TotalPrice).IsRequired();
            builder.Property(sc => sc.CreatedAt).IsRequired();
            builder.Property(sc => sc.UpdatedAt).IsRequired();
            builder.HasMany(sc => sc.Products).WithMany(p => p.ShoppingCarts);
            builder.HasIndex(builder => builder.UserId).IsUnique();
            builder.HasOne(sc => sc.User).WithOne(u => u.ShoppingCart).HasForeignKey<User>(u => u.ShoppingCartId).HasPrincipalKey<ShoppingCart>(sc => sc.Id).IsRequired();
        }
    }
}
