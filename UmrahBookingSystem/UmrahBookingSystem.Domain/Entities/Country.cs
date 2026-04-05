using UmrahBookingSystem.Domain.Common;

namespace UmrahBookingSystem.Domain.Entities
{
    public class Country : BaseEntity
    {
        public int Id { get; set; }
        public string CountryName { get; set; } = null!;
        public ICollection<City> Cities { get; set; } = new List<City>();
    }
}
