using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UmrahBookingSystem.Domain.Entities;

namespace UmrahBookingSystem.Infrastructure.Persistence.Configurations
{
    public class PassengerConfiguration : BaseEntityConfiguration<Passenger>
    {
        public override void Configure(EntityTypeBuilder<Passenger> builder)
        {
            base.Configure(builder);

            builder.ToTable("Passengers");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.DateOfBirth)
                .IsRequired();

            builder.Property(p => p.PassportNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.PassportExpiryDate)
                .IsRequired();

            builder.Property(p => p.PassportImageUrl)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(p => p.PersonalPhotoUrl)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(p => p.VerificationStatus)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(p => p.VerificationNote)
                .IsRequired(false)
                .HasMaxLength(2500);
        }
    }
}