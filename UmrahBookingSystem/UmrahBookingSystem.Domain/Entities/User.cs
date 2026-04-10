
namespace UmrahBookingSystem.Domain.Entities
{
    public class User
    {
        public string Id { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string? ProfilePhotoUrl { get; set; }
        public int LocationId { get; set; }
        public int RoleId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }

        // Navigation properties
        public Location Location { get; set; } = null!;
        public UserRole Role { get; set; } = null!;
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
        public ICollection<WaitingList> WaitingLists { get; set; } = new List<WaitingList>();
    }
}
