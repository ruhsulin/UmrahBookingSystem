using UmrahBookingSystem.Domain.Common;
using UmrahBookingSystem.Domain.Enums;

namespace UmrahBookingSystem.Domain.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Message { get; set; } = null!;
        public bool IsRead { get; set; }
        public NotificationType Type { get; set; }
        public DateTime CreatedAt { get; set; } 
        public string UserId { get; set; } = null!;

        //navigation property
        public User User { get; set; } = null!;
    }
}
