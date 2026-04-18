namespace UmrahBookingSystem.Application.DTOs.Bookings
{
    public class BookingDto
    {
        public int Id { get; set;  }
        public DateTime BookingDate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
