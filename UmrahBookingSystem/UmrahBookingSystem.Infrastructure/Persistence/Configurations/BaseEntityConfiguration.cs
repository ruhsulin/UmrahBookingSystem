using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UmrahBookingSystem.Domain.Common;

namespace UmrahBookingSystem.Infrastructure.Persistence.Configurations
{
    public class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(e => e.CreatedAt)
                .IsRequired();

            builder.Property(e => e.CreatedBy)
                .IsRequired();

            builder.Property(e => e.UpdatedAt)
                .IsRequired(false);

            builder.Property(e => e.UpdatedBy)
                .IsRequired(false);
        }
    }
}