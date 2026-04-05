using UmrahBookingSystem.Domain.Common;

namespace UmrahBookingSystem.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string? RecordedByAdminId { get; set; }
        public string? StripePaymentIntentId { get; set; }

        public int BookingId { get; set; }

        // Navigation property
        public Booking Booking { get; set; } = null!;
        public User? RecordedByAdmin { get; set; }
    }
}
