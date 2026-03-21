namespace UmrahBookingSystem.Domain.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? PaymentMethod { get; set; }
        public string? Status { get; set; }
        public int BookingId { get; set; }
        // Navigation property
        public Booking Booking { get; set; } = null!;
    }
}
