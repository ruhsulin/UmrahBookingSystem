using UmrahBookingSystem.Domain.Common;

namespace UmrahBookingSystem.Domain.Entities
{
    public class Activity : BaseEntity
    {
        public int Id { get; set; }
        public string ActivityName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int LocationId { get; set; } 
        public Location Location { get; set; } = null!;
        public ICollection<PackageActivity> PackageActivities { get; set; } = new List<PackageActivity>();
        public ICollection<ActivityImage> ActivityImages { get; set; } = new List<ActivityImage>(); 
    }
}
