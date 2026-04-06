using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UmrahBookingSystem.Domain.Entities;

namespace UmrahBookingSystem.Infrastructure.Persistence.Configurations
{
    public class UserRoleConfiguration : BaseEntityConfiguration<UserRole>
    {
        public override void Configure(EntityTypeBuilder<UserRole> builder)
        {
            base.Configure(builder);

            builder.ToTable("UserRoles");

            builder.HasKey(ur => ur.Id);

            builder.Property(ur => ur.RoleName)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}