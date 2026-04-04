namespace UmrahBookingSystem.Domain.Entities
{
    public class HotelImage
    {
        public int Id { get; set; }
        public required string ImageUrl { get; set; }
        public required int HotelId { get; set; }
        public Hotel Hotel { get; set; } = null!;  
    }
}
