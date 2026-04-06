using UmrahBookingSystem.Domain.Common;

namespace UmrahBookingSystem.Domain.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Message { get; set; } = null!;
        public bool IsRead { get; set; }
        public string Type { get; set; } = null!;
        public DateTime CreatedAt { get; set; } 
        public string UserId { get; set; } = null!;

        //navigation property
        public User User { get; set; } = null!;
    }
}
