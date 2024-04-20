using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Infrastructure.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasMaxLength(255).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(1000).IsRequired(false);
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.CreatedAt).IsRequired();
            builder.Property(p => p.UpdatedAt).IsRequired();
            builder.HasMany(p => p.Reviews).WithOne(r => r.ReviewedProduct).HasPrincipalKey(p => p.Id).HasForeignKey(r => r.ReviewedProductId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(p => p.ShoppingCarts).WithMany(sc => sc.Products);
        }   
    }
}
