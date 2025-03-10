using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

using AdvertiseService.Domain.Entities;

namespace AdvertiseService.Infrastructure.Configurations
{
    public class AdEntityTypeConfiguration : IEntityTypeConfiguration<Ad>

    {

        public void Configure(EntityTypeBuilder<Ad> builder)

        {

            builder.ToTable("Ads");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Title).HasMaxLength(100).IsRequired();
            builder.Property(a => a.PriceAmount).HasColumnType("decimal(18,2)");
            builder.Property(a => a.ExpirationDate).IsRequired();

            //builder.HasMany(a => a.Images).WithOne().OnDelete(DeleteBehavior.Cascade);
            //builder.HasMany(a => a.History).WithOne().OnDelete(DeleteBehavior.Cascade);

        }

    }
}
