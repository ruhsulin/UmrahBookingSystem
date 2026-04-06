using UmrahBookingSystem.Domain.Enums;

namespace UmrahBookingSystem.Domain.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public required DateTime BookingDate { get; set; }
        public required int NumPassengers { get; set; }
        public required decimal TotalPrice {  get; set; }
        public required BookingStatus Status { get; set; }
        public required string UserId { get; set; }
        public required int PackageId { get; set; }


        // Navigation properties
        public User User { get; set; } = null!;
        public Package Package { get; set; } = null!;

        public ICollection<Passenger> Passengers { get; set; } = new List<Passenger>();
        public ICollection<BookingRoom> BookingRooms { get; set; } = new List<BookingRoom>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
