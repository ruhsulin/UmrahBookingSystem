using UmrahBookingSystem.Domain.Common;

namespace UmrahBookingSystem.Domain.Entities
{
    public class Service : BaseEntity, IEntity<int>
    {
        public int Id { get; set; }
        public string ServiceName { get; set; } = null!;
        public ICollection<PackageService> PackageServices { get; set; } = new List<PackageService>();
    }
}
