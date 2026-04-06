using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UmrahBookingSystem.Domain.Entities;

namespace UmrahBookingSystem.Infrastructure.Persistence.Configurations
{
    public class ActivityConfiguration : BaseEntityConfiguration<Activity>
    {
        public override void Configure(EntityTypeBuilder<Activity> builder)
        {
            base.Configure(builder);

            builder.ToTable("Activities");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.ActivityName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.Description)
                .IsRequired()
                .HasMaxLength(250);
        }
    }
}
