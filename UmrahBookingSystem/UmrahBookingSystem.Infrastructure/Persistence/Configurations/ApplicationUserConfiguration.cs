using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UmrahBookingSystem.Domain.Entities;
using UmrahBookingSystem.Infrastructure.Identity;

namespace UmrahBookingSystem.Infrastructure.Persistence.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasOne<User>()
                .WithOne()
                .HasForeignKey<ApplicationUser>(a => a.Id)
                .OnDelete(DeleteBehavior.Restrict);

            // PhoneNumber is not used on accounts; the only phone number is Users.PhoneNumber.
            builder.ToTable("AspNetUsers", t => t.HasCheckConstraint(
                "CK_AspNetUsers_PhoneNumber_IsNull",
                "[PhoneNumber] IS NULL"));
        }
    }
}
