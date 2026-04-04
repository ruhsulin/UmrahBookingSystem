
namespace UmrahBookingSystem.Domain.Entities
{
    public class UserRole
    {
        public int Id { get; set; }
        public required string RoleName { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
