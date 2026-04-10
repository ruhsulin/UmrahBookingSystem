using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UmrahBookingSystem.Domain.Entities;

namespace UmrahBookingSystem.Infrastructure.Persistence.Configurations
{
    public class PackageActivityConfiguration : BaseEntityConfiguration<PackageActivity>
    {
        public override void Configure(EntityTypeBuilder<PackageActivity> builder)
        {
            base.Configure(builder);

            builder.ToTable("PackageActivities");

            builder.HasKey(pa => pa.Id);

            builder.Property(pa => pa.PackageId)
                .IsRequired();

            builder.Property(pa => pa.ActivityId)
                .IsRequired();

            builder.HasOne(pa => pa.Activity)
                .WithMany(a => a.PackageActivities)
                .HasForeignKey(pa => pa.ActivityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pa => pa.Package)
                .WithMany(p => p.PackageActivities)
                .HasForeignKey(pa => pa.PackageId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
