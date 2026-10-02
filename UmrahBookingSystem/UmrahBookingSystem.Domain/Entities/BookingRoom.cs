using UmrahBookingSystem.Domain.Common;

namespace UmrahBookingSystem.Domain.Entities
{
    public class BookingRoom : BaseEntity
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int BookingId { get; set; }
        public int PackageRoomId { get; set; }
        public decimal PricePerPerson { get; set; } // snapshot:price at booking time

        // Navigation properties
        public Booking Booking { get; set; } = null!;
        public PackageRoom PackageRoom { get; set; } = null!;
    }
}
