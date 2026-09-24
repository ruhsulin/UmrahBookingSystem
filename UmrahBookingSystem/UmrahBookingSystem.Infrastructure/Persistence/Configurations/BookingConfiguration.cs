using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UmrahBookingSystem.Domain.Entities;
using UmrahBookingSystem.Domain.Enums;

namespace UmrahBookingSystem.Infrastructure.Persistence.Configurations
{
    public class BookingConfiguration : BaseEntityConfiguration<Booking>
    {
        public override void Configure(EntityTypeBuilder<Booking> builder)
        {
            base.Configure(builder);

            builder.ToTable("Bookings");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.BookingDate)
                .IsRequired();

            builder.Property(b => b.NumPassengers)
                .IsRequired();

            builder.Property(b => b.TotalPrice)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(b => b.Status)
                .HasConversion<string>()
                .IsRequired()
                .HasDefaultValue(BookingStatus.Pending);

            builder.HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.Package)
                .WithMany(p => p.Bookings)
                .HasForeignKey(b => b.PackageId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(b => b.UserId)
         .      HasDatabaseName("IX_Bookings_UserId");

            builder.HasIndex(b => b.PackageId)
               .HasDatabaseName("IX_Bookings_PackageId");
        }
    }
}
