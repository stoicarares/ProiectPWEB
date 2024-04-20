using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Infrastructure.EntityConfigurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.Property(r => r.Id).IsRequired();
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Title).HasMaxLength(255).IsRequired();
            builder.Property(r => r.Content).HasMaxLength(5000).IsRequired(false);
            builder.Property(r => r.Rating).IsRequired();
            builder.HasOne(r => r.ReviewedProduct).WithMany(p => p.Reviews).HasForeignKey(r => r.ReviewedProductId).HasPrincipalKey(p => p.Id).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(r => r.User).WithMany(u => u.Reviews).HasForeignKey(r => r.UserId).HasPrincipalKey(u => u.Id).IsRequired().OnDelete(DeleteBehavior.Cascade);
        }

    }
}
