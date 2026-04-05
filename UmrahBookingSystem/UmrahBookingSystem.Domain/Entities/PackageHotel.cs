using UmrahBookingSystem.Domain.Common;

namespace UmrahBookingSystem.Domain.Entities
{
    public class PackageHotel : BaseEntity
    {
        public int Id { get; set; }
        public int PackageId { get; set; }
        public int HotelId { get; set; }

        public Hotel Hotel { get; set; } = null!;
        public Package Package { get; set; } = null!;
    }
}
