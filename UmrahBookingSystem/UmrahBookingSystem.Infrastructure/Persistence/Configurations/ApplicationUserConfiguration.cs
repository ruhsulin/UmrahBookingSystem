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
        }
    }
}
