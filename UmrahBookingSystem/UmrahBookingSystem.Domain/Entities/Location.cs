namespace UmrahBookingSystem.Domain.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public required string StreetName { get; set; }
        public string? DoorNumber { get; set; }
        public string? PostalCode { get; set; }
        public required int CityId { get; set; }
        public City City { get; set; } = null!;
        public ICollection<Activity> Activities{ get; set; }  = new List<Activity>();
        public ICollection<Hotel> Hotels { get; set; }  = new List<Hotel>();
    }
}
