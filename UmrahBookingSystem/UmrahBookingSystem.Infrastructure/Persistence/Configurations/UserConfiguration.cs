using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UmrahBookingSystem.Domain.Entities;

namespace UmrahBookingSystem.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(250);
            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(u => u.PhoneNumber)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(u => u.DateOfBirth)
                .IsRequired();

            builder.Property(u => u.ProfilePhotoUrl)
                .IsRequired(false)
                .HasMaxLength(500);

            builder.Property(u => u.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(u => u.UpdatedAt)
                .IsRequired(false);

            builder.Property(u => u.UpdatedBy)
                .IsRequired(false);

            builder.HasOne(u => u.Location)
                .WithMany()
                .HasForeignKey(u => u.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

           builder.HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

           builder.Property( u => u.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}
