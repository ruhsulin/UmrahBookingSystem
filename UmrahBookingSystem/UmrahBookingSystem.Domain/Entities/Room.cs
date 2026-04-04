namespace UmrahBookingSystem.Domain.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public required int RoomType { get; set; }
        public required decimal RoomPrice { get; set; }

        public ICollection<BookingRoom> BookingRooms { get; set; } = new List<BookingRoom>();
    }
}
