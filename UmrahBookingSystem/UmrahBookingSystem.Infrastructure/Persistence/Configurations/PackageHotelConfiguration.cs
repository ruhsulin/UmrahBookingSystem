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

            builder.HasOne(ph => ph.Hotel)
                .WithMany(h => h.PackageHotels)
                .HasForeignKey(ph => ph.HotelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ph => ph.Package)
                .WithMany(p => p.PackageHotels)
                .HasForeignKey(ph => ph.PackageId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
