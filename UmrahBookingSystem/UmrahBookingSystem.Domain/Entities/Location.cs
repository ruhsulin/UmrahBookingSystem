using UmrahBookingSystem.Domain.Common;

namespace UmrahBookingSystem.Domain.Entities
{
    public class Location : BaseEntity
    {
        public int Id { get; set; }
        public string StreetName { get; set; } = null!;
        public string? DoorNumber { get; set; }
        public string? PostalCode { get; set; }
        public int CityId { get; set; }
        public City City { get; set; } = null!;
        public ICollection<Activity> Activities{ get; set; }  = new List<Activity>();
        public ICollection<Hotel> Hotels { get; set; }  = new List<Hotel>();
    }
}
