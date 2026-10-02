using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UmrahBookingSystem.Domain.Entities;

namespace UmrahBookingSystem.Infrastructure.Persistence.Configurations
{
    public class BookingRoomConfiguration : BaseEntityConfiguration<BookingRoom>
    {
        public override void Configure(EntityTypeBuilder<BookingRoom> builder)
        {
            base.Configure(builder);

            builder.ToTable("BookingRooms");

            builder.HasKey(br => br.Id);

            builder.Property(br => br.BookingId)
                .IsRequired();

            builder.Property(br => br.Quantity)
                .IsRequired();

            builder.HasOne(br => br.Booking)
                .WithMany(b => b.BookingRooms)
                .HasForeignKey(br => br.BookingId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(br => br.PackageRoomId)
                    .IsRequired();

            builder.Property(br => br.PricePerPerson)
                     .IsRequired()
                     .HasPrecision(18, 2);

            builder.HasOne(br => br.PackageRoom)
                     .WithMany(pr => pr.BookingRooms)
                     .HasForeignKey(br => br.PackageRoomId)
                     .OnDelete(DeleteBehavior.Restrict);   // a booked price can't disappear
        }
    }
}
