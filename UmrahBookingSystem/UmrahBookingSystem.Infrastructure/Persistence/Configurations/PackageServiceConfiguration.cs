using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UmrahBookingSystem.Domain.Entities;

namespace UmrahBookingSystem.Infrastructure.Persistence.Configurations
{
    public class PackageServiceConfiguration : BaseEntityConfiguration<PackageService>
    {
        public override void Configure(EntityTypeBuilder<PackageService> builder)
        {
            base.Configure(builder);

            builder.ToTable("PackageServices");

            builder.HasKey(ps => ps.Id);

            builder.Property(ps => ps.Price)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(ps => ps.PackageId)
                .IsRequired();

            builder.Property(ps => ps.ServiceId)
                .IsRequired();

            builder.HasOne(ps => ps.Package)
                .WithMany(p => p.PackageServices)
                .HasForeignKey(ps => ps.PackageId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ps => ps.Service)
                .WithMany(s => s.PackageServices)
                .HasForeignKey(ps => ps.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}