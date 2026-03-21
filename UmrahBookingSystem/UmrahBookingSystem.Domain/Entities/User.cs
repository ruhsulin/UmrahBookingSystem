
namespace UmrahBookingSystem.Domain.Entities
{
    public class User
    {
        public string Id { get; set; } = null!;
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; } = null!;
        public int UserRoleId { get; set; }
        public UserRole UserRole { get; set; } = null!;
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}

