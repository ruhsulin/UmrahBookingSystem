using UmrahBookingSystem.Domain.Common;
using UmrahBookingSystem.Domain.Enums;

namespace UmrahBookingSystem.Domain.Entities
{
    public  class PackageRoom : BaseEntity
    {
        public int Id { get; set; }
        public int PackageId { get; set; }
        public RoomType RoomType { get; set; }
        public decimal PricePerPerson { get; set; }
  
        // Navigation properties
        public Package Package { get; set; } = null!;
        public ICollection<BookingRoom> BookingRooms { get; set; } = new List<BookingRoom>();
    }
}
