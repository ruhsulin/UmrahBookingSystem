using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UmrahBookingSystem.Domain.Entities;

namespace UmrahBookingSystem.Infrastructure.Persistence.Configurations
{
    public class HotelConfiguration : BaseEntityConfiguration<Hotel>
    {
        public override void Configure(EntityTypeBuilder<Hotel> builder)
        {
            base.Configure(builder);

            builder.ToTable("Hotels");

            builder.HasKey(h => h.Id);

            builder.Property(h => h.Stars)
                .IsRequired();

            builder.Property(h => h.HotelName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}