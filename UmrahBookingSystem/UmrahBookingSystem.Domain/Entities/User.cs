
namespace UmrahBookingSystem.Domain.Entities
{
    public class User
    {
        public string Id { get; set; } = null!;
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public string? ProfilePhotoUrl { get; set; }
        public required int LocationId { get; set; }
        public required int RoleId { get; set; }
        public required DateTime CreatedAt { get; set; }
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

