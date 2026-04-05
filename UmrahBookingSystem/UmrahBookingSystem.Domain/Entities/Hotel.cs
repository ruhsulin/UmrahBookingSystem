using UmrahBookingSystem.Domain.Common;

namespace UmrahBookingSystem.Domain.Entities
{
    public class Hotel : BaseEntity
    {
        public int Id { get; set; }
        public int Stars { get; set; }
        public string HotelName { get; set; } = null!;
        public int LocationId { get; set; }
        public Location Location { get; set; } = null!;
        public ICollection<PackageHotel> PackageHotels { get; set; } = new List<PackageHotel>();
        public ICollection<HotelImage> HotelImages { get; set; } = new List<HotelImage>();
    }
}
