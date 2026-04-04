namespace UmrahBookingSystem.Domain.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        public required int Stars { get; set; }
        public required string HotelName { get; set; }
        public required int LocationId { get; set; }
        public Location Location { get; set; } = null!;
        public ICollection<PackageHotel> PackageHotels { get; set; } = new List<PackageHotel>();
        public ICollection<HotelImage> HotelImages { get; set; } = new List<HotelImage>();
    }
}
