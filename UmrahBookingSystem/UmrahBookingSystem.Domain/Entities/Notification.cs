using UmrahBookingSystem.Domain.Enums;

namespace UmrahBookingSystem.Domain.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Message { get; set; }
        public required bool IsRead { get; set; }
        public required NotificationType Type { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required string UserId { get; set; }

        //navigation property
        public User User { get; set; } = null!;
    }
}
