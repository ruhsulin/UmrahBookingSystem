using UmrahBookingSystem.Domain.Common;

namespace UmrahBookingSystem.Domain.Entities
{
    public class HotelImage : BaseEntity
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = null!;
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; } = null!;  
    }
}
