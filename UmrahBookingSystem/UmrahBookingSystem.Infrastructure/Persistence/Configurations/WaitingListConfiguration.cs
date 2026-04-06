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
        }
    }
}