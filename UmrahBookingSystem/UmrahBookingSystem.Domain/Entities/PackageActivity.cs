namespace UmrahBookingSystem.Domain.Entities
{
    public class PackageActivity
    {
        public int Id { get; set; }
        public required int PackageId { get; set; }
        public required int ActivityId { get; set; }

        public Package Package { get; set; } = null!;
        public Activity Activity { get; set; } = null!;
    }
}
