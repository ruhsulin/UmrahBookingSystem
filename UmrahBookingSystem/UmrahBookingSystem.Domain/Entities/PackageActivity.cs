namespace UmrahBookingSystem.Domain.Entities
{
    public class PackageActivity
    {
        public int Id { get; set; }
        public int PackageId { get; set; }
        public Package Package { get; set; } = null!;
        public int ActivityId { get; set; }
        public Activity Activity { get; set; } = null!;
    }
}
