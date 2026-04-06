using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UmrahBookingSystem.Domain.Entities;

namespace UmrahBookingSystem.Infrastructure.Persistence.Configurations
{
    public class CountryConfiguration : BaseEntityConfiguration<Country>
    {
        public override void Configure(EntityTypeBuilder<Country> builder)
        {
            base.Configure(builder);

            builder.ToTable("Countries");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.CountryName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}