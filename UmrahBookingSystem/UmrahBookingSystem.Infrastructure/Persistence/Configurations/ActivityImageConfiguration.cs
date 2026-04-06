using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UmrahBookingSystem.Domain.Entities;

namespace UmrahBookingSystem.Infrastructure.Persistence.Configurations
{
    public class ActivityImageConfiguration : BaseEntityConfiguration<ActivityImage>
    {
        public override void Configure(EntityTypeBuilder<ActivityImage> builder)
        {
            base.Configure(builder);

            builder.ToTable("ActivityImages");

            builder.HasKey(ai => ai.Id);

            builder.Property(ai => ai.ImageUrl)
                .IsRequired()
                .HasMaxLength(500);
        }
    }
}
