using UmrahBookingSystem.Domain.Common;

namespace UmrahBookingSystem.Domain.Entities
{
    public class ActivityImage : BaseEntity
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = null!;
        public int ActivityId { get; set; }
        public Activity Activity { get; set; } = null!;
    }
}
