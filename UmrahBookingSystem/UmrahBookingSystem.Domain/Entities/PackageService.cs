using UmrahBookingSystem.Domain.Common;

namespace UmrahBookingSystem.Domain.Entities
{
    public class PackageService : BaseEntity
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int PackageId { get; set; }
        public int ServiceId { get; set; }

        public Package Package { get; set; } = null!;
        public Service Service { get; set; } = null!;
    }
}
