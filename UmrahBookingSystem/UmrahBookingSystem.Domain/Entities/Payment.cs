using UmrahBookingSystem.Domain.Enums;

namespace UmrahBookingSystem.Domain.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public required decimal Amount { get; set; }
        public required DateTime PaymentDate { get; set; }
        public required PaymentMethod PaymentMethod { get; set; }
        public required PaymentStatus Status { get; set; }
        public required PaymentType Type { get; set; }
        public string? RecordedByAdminId { get; set; }
        public string? StripePaymentIntentId { get; set; }

        public required int BookingId { get; set; }

        // Navigation property
        public Booking Booking { get; set; } = null!;
        public User? RecordedByAdmin { get; set; }
    }
}
