namespace UmrahBookingSystem.Domain.Entities
{
    public class WaitingList
    {
        public int Id { get; set; }
        public required DateTime RegisteredAt { get; set; }
        public required int PackageId { get; set; }
        public required string UserId { get; set; }

        //navigation properties
        public User User { get; set; } = null!;
        public Package Package { get; set; } = null!;
    }
}
