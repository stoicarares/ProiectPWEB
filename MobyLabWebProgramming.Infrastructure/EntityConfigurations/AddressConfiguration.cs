using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Infrastructure.EntityConfigurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(a => a.Id).IsRequired();
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Street).HasMaxLength(400).IsRequired();
            builder.Property(a => a.Number).IsRequired();
            builder.Property(a => a.City).HasMaxLength(100).IsRequired();
            builder.Property(a => a.State).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Country).HasMaxLength(100).IsRequired();
            builder.Property(a => a.PostalCode).HasMaxLength(100).IsRequired();
            builder.HasOne(a => a.User).WithMany(u => u.Addresses).HasForeignKey(a => a.UserId).HasPrincipalKey(a => a.Id).IsRequired();
        }
    }

}
