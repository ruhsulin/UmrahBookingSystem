namespace UmrahBookingSystem.Domain.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public required string StreetName { get; set; }
        public required string DoorNumber { get; set; }
        public required string PostalCode { get; set; }
        public int CityId { get; set; }
        public City City { get; set; } = null!;
        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<Activity> Activities{ get; set; }  = new List<Activity>();
        public ICollection<Hotel> Hotels { get; set; }  = new List<Hotel>();
    }
}
