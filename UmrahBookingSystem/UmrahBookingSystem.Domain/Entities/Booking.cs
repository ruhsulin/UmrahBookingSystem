namespace UmrahBookingSystem.Domain.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime BookingDate { get; set; }
        public int NumberOfPeople { get; set; }
        public decimal TotalPrice {  get; set; }
        public string? Status { get; set; }
        public string? UserId { get; set; }
        public int PackageId { get; set; }
        public int RoomId { get; set; }


        // Navigation properties
        public User User { get; set; } = null!;
        public Package Package { get; set; } = null!;
        public Room Room { get; set; } = null!;
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
