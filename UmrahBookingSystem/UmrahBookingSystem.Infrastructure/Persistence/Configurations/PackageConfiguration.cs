using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UmrahBookingSystem.Domain.Entities;

namespace UmrahBookingSystem.Infrastructure.Persistence.Configurations
{
    public class PackageConfiguration : BaseEntityConfiguration<Package>
    {
        public override void Configure(EntityTypeBuilder<Package> builder)
        {
            base.Configure(builder);

            builder.ToTable("Packages");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.PackageName)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(p => p.DepartureDate)
                .IsRequired();

            builder.Property(p => p.ReturnDate)
                .IsRequired();

            builder.Property(p => p.DepartureTime)
                .IsRequired();

            builder.Property(p => p.MaxPassenger)
                .IsRequired();

            builder.Property(p => p.BaggageAllowance)
                .IsRequired();

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(2500);

            builder.Property(p => p.CoverImageUrl)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(p => p.BasePrice)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(p => p.DepartureAirport)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.ArrivalAirport)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.TransitAirport)
                .IsRequired(false)
                .HasMaxLength(100);

            builder.Property(p => p.AirlineName)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(p => p.DepartureFlightNumber)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(p => p.ReturnFlightNumber)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(p => p.ReturnTime)
                .IsRequired();

            builder.Property(p => p.AvailableSpots)
                .IsRequired();

            builder.Property(p => p.PaymentDeadlineDays)
                .IsRequired();
        }
    }
}
