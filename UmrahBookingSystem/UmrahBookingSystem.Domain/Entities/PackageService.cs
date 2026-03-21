namespace UmrahBookingSystem.Domain.Entities
{
    public class PackageService
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int PackageId { get; set; }
        public Package Package { get; set; } = null!;
        public int ServiceId { get; set; }
        public Service Service { get; set; } = null!;
    }
}
