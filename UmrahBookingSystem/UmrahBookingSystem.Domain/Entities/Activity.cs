namespace UmrahBookingSystem.Domain.Entities
{
    public class Activity
    {
        public int Id { get; set; }
        public required string ActivityName { get; set; }
        public required string Description { get; set; }
        public required int LocationId { get; set; }
        public Location Location { get; set; } = null!;
        public ICollection<PackageActivity> PackageActivities { get; set; } = new List<PackageActivity>();
        public ICollection<ActivityImage> ActivityImages { get; set; } = new List<ActivityImage>(); 
    }
}
