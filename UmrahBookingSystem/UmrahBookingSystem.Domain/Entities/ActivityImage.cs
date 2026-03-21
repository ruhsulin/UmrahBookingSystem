namespace UmrahBookingSystem.Domain.Entities
{
    public class ActivityImage
    {
        public int Id { get; set; }
        public required string ImageUrl { get; set; }
        public int ActivityId { get; set; }
        public Activity Activity { get; set; } = null!;
    }
}
