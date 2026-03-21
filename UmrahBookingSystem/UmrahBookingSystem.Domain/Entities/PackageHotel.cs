namespace UmrahBookingSystem.Domain.Entities
{
    public class PackageHotel
    {
        public int Id { get; set; }
        public int PackageId { get; set; }
        public Package Package { get; set; } = null!;
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; } = null!;
    }
}
