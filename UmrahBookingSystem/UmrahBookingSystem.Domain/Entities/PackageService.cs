namespace UmrahBookingSystem.Domain.Entities
{
    public class PackageService
    {
        public int Id { get; set; }
        public required decimal Price { get; set; }
        public required int PackageId { get; set; }
        public required int ServiceId { get; set; }

        public Package Package { get; set; } = null!;
        public Service Service { get; set; } = null!;
    }
}
