namespace UmrahBookingSystem.Domain.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public required string ServiceName { get; set; }
        public ICollection<PackageService> PackageServices { get; set; } = new List<PackageService>();
    }
}
