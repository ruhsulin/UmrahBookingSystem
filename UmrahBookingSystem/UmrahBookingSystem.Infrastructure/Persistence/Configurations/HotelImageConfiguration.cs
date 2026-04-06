using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UmrahBookingSystem.Domain.Entities;

namespace UmrahBookingSystem.Infrastructure.Persistence.Configurations
{
    public class HotelImageConfiguration : BaseEntityConfiguration<HotelImage>
    {
        public override void Configure(EntityTypeBuilder<HotelImage> builder)
        {
            base.Configure(builder);

            builder.ToTable("HotelImages");

            builder.HasKey(hi => hi.Id);

            builder.Property(hi => hi.ImageUrl)
                .IsRequired()
                .HasMaxLength(500);
        }
    }
}