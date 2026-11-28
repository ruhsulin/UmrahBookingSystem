using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UmrahBookingSystem.Domain.Entities;

namespace UmrahBookingSystem.Infrastructure.Persistence.Configurations
{
    public class ServiceConfiguration : BaseEntityConfiguration<Service>
    {
        public override void Configure(EntityTypeBuilder<Service> builder)
        {
            base.Configure(builder);

            builder.ToTable("Services");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.ServiceName)
                    .IsRequired()
                    .HasMaxLength(250);

            builder.HasIndex(s => s.ServiceName)
                    .IsUnique()
                    .HasFilter("[IsDeleted] = 0")
                    .HasDatabaseName("IX_Services_ServiceName");
        }
    }
}
