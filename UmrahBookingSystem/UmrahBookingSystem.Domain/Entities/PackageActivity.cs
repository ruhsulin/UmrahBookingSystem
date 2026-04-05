using UmrahBookingSystem.Domain.Common;

namespace UmrahBookingSystem.Domain.Entities
{
    public class PackageActivity : BaseEntity
    {
        public int Id { get; set; }
        public int PackageId { get; set; }
        public int ActivityId { get; set; }

        public Package Package { get; set; } = null!;
        public Activity Activity { get; set; } = null!;
    }
}
