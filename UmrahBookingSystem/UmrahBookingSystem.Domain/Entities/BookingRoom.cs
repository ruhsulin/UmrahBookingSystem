using UmrahBookingSystem.Domain.Common;

namespace UmrahBookingSystem.Domain.Entities
{
    public class BookingRoom :BaseEntity
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int BookingId { get; set; }
        public int RoomId { get; set; }

        // Navigation properties
        public Booking Booking { get; set; } = null!;
        public Room Room { get; set; } = null!;
    }
}
