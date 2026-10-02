using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UmrahBookingSystem.Domain.Entities;

namespace UmrahBookingSystem.Infrastructure.Persistence.Configurations
{
    public class PackageRoomConfiguration : BaseEntityConfiguration<PackageRoom>
    {
        public override void Configure(EntityTypeBuilder<PackageRoom> builder)
        {
            base.Configure(builder);

            builder.ToTable("PackageRooms");

            builder.HasKey(pr => pr.Id);

            builder.Property(pr => pr.PackageId)
                .IsRequired();

            builder.Property(pr => pr.RoomType)
                .IsRequired()
                .HasConversion<string>() // stored as "Triple", "Double", "Quad" or "Single".
                .HasMaxLength(20);

            builder.Property(pr => pr.PricePerPerson)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.HasIndex(pr => new { pr.PackageId, pr.RoomType })
                .IsUnique()
                .HasFilter("[IsDeleted] = 0")
                .HasDatabaseName("IX_PackageRooms_PackageId_RoomType");

            builder.HasOne(pr => pr.Package)
                .WithMany(p => p.PackageRooms)
                .HasForeignKey(pr => pr.PackageId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}