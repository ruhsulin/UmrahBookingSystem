using UmrahBookingSystem.Domain.Common;
using UmrahBookingSystem.Domain.Enums;

namespace UmrahBookingSystem.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentStatus Status { get; set; }
        public PaymentType Type { get; set; }
        public string? RecordedByAdminId { get; set; }
        public string? StripePaymentIntentId { get; set; }

        public int BookingId { get; set; }

        // Navigation property
        public Booking Booking { get; set; } = null!;
        public User? RecordedByAdmin { get; set; }
    }
}
