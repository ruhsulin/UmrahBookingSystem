using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UmrahBookingSystem.Domain.Entities;

namespace UmrahBookingSystem.Infrastructure.Persistence.Configurations
{
    public class LocationConfiguration : BaseEntityConfiguration<Location>
    {
        public override void Configure(EntityTypeBuilder<Location> builder)
        {
            base.Configure(builder);

            builder.ToTable("Locations");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.StreetName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(l => l.DoorNumber)
                .IsRequired(false)
                .HasMaxLength(10);

            builder.Property(l => l.PostalCode)
                .IsRequired(false)
                .HasMaxLength(25);

            builder.HasOne(l => l.City)
                .WithMany(c => c.Locations)
                .HasForeignKey(l => l.CityId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
