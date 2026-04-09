using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UmrahBookingSystem.Domain.Entities;

namespace UmrahBookingSystem.Infrastructure.Persistence.Configurations
{
    public class WaitingListConfiguration : BaseEntityConfiguration<WaitingList>
    {
        public override void Configure(EntityTypeBuilder<WaitingList> builder)
        {
            base.Configure(builder);

            builder.ToTable("WaitingLists");

            builder.HasKey(w => w.Id);

            builder.Property(w => w.RegisteredAt).
                IsRequired();

            builder.HasOne(wl => wl.User)
                .WithMany(u => u.WaitingLists)
                .HasForeignKey(wl => wl.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(wl => wl.Package)
                .WithMany(p => p.WaitingLists)
                .HasForeignKey(wl => wl.PackageId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}