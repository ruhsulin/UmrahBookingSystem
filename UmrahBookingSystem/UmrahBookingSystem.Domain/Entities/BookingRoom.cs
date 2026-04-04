namespace UmrahBookingSystem.Domain.Entities
{
    public class BookingRoom
    {
        public int Id { get; set; }
        public required int Quantity { get; set; }
        public required int BookingId { get; set; }
        public required int RoomId { get; set; }

        // Navigation properties
        public Booking Booking { get; set; } = null!;
        public Room Room { get; set; } = null!;
    }
}
