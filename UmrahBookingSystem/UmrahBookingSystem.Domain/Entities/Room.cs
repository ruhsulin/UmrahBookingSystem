using UmrahBookingSystem.Domain.Common;

namespace UmrahBookingSystem.Domain.Entities
{
    public class Room : BaseEntity
    {
        public int Id { get; set; }
        public int RoomType { get; set; }
        public decimal RoomPrice { get; set; }

        public ICollection<BookingRoom> BookingRooms { get; set; } = new List<BookingRoom>();
    }
}
