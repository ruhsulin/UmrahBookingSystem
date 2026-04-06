using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UmrahBookingSystem.Domain.Entities;

namespace UmrahBookingSystem.Infrastructure.Persistence.Configurations
{
    public class PackageHotelConfiguration : BaseEntityConfiguration<PackageHotel>
    {
        public override void Configure(EntityTypeBuilder<PackageHotel> builder)
        {
            base.Configure(builder);

            builder.ToTable("PackageHotels");

            builder.HasKey(ph => ph.Id);

            builder.Property(ph => ph.PackageId)
                .IsRequired();

            builder.Property(ph => ph.HotelId)
                .IsRequired();
        }
    }
}