using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UmrahBookingSystem.Domain.Entities;

namespace UmrahBookingSystem.Infrastructure.Persistence.Configurations
{
    public class PaymentConfiguration : BaseEntityConfiguration<Payment>
    {
        public override void Configure(EntityTypeBuilder<Payment> builder)
        {
            base.Configure(builder);

            builder.ToTable("Payments");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Amount)
                .IsRequired()
                .HasPrecision(18,2);

            builder.Property(p => p.PaymentDate)
                .IsRequired();

            builder.Property(p => p.PaymentMethod)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(p => p.Status)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(p => p.Type)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(p => p.RecordedByAdminId)
                .IsRequired(false);

            builder.Property(p => p.StripePaymentIntentId)
                .IsRequired(false);

                builder.HasOne(p => p.Booking)
                .WithMany(b => b.Payments)
                .HasForeignKey(p => p.BookingId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.RecordedByAdmin)
                .WithMany()
                .HasForeignKey(p => p.RecordedByAdminId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
