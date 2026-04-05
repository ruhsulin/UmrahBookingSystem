using UmrahBookingSystem.Domain.Common;

namespace UmrahBookingSystem.Domain.Entities
{
    public class Booking : BaseEntity
    {
        public int Id { get; set; }
        public DateTime BookingDate { get; set; }
        public int NumPassengers { get; set; }
        public decimal TotalPrice {  get; set; }
        public string Status { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public int PackageId { get; set; } 

        // Navigation properties
        public User User { get; set; } = null!;
        public Package Package { get; set; } = null!;

        public ICollection<Passenger> Passengers { get; set; } = new List<Passenger>();
        public ICollection<BookingRoom> BookingRooms { get; set; } = new List<BookingRoom>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
