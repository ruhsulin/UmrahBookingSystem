using UmrahBookingSystem.Domain.Common;

namespace UmrahBookingSystem.Domain.Entities
{
    public class City : BaseEntity
    {
        public int Id { get; set; }
        public string CityName { get; set; } = null!;

        public int CountryId { get; set; }
        public Country Country { get; set; } = null!;
        public ICollection<Location> Locations { get; set; } = new List<Location>();
    }
}
