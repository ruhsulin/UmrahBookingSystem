using UmrahBookingSystem.Domain.Common;

namespace UmrahBookingSystem.Domain.Entities
{
    public class WaitingList : BaseEntity
    {
        public int Id { get; set; }
        public DateTime RegisteredAt { get; set; }
        public int PackageId { get; set; }
        public string UserId { get; set; } = null!;

        //navigation properties
        public User User { get; set; } = null!;
        public Package Package { get; set; } = null!;
    }
}
