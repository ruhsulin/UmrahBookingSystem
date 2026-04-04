namespace UmrahBookingSystem.Domain.Entities
{
    public class City
    {
        public int Id { get; set; }
        public required string CityName { get; set; }

        public required int CountryId { get; set; }
        public Country Country { get; set; } = null!;
        public ICollection<Location> Locations { get; set; } = new List<Location>();
    }
}
