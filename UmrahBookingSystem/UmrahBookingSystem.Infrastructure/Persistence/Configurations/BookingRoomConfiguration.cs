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

                builder.Property(br => br.RoomId)
                    .IsRequired();

                builder.Property(br => br.Quantity)
                    .IsRequired();

                builder.HasOne(br => br.Booking)
                    .WithMany(b => b.BookingRooms)
                    .HasForeignKey(br => br.BookingId)
                    .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne(br => br.Room)
                    .WithMany(r => r.BookingRooms)
                    .HasForeignKey(br => br.RoomId)
                    .OnDelete(DeleteBehavior.Restrict);
            }
        }
}
