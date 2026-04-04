namespace UmrahBookingSystem.Domain.Entities
{
    public class Package
    {
        public int Id { get; set; }
        public required string PackageName { get; set; }
        public required DateTime DepartureDate { get; set; }
        public required DateTime ReturnDate { get; set; }
        public required DateTime DepartureTime { get; set; }
        public required int MaxPassenger { get; set; }
        public required int BaggageAllowance { get; set; }
        public required string Description { get; set; }
        public required string CoverImageUrl { get; set; }
        public required decimal BasePrice { get; set; }
        public required string DepartureAirport { get; set; }
        public required string ArrivalAirport { get; set; }
        public string? TransitAirport { get; set; }
        public required string AirlineName { get; set; }

        public required string DepartureFlightNumber { get; set; }
        public required string ReturnFlightNumber { get; set; }
        public required DateTime ReturnTime { get; set; }
        public required int AvailableSpots { get; set; }
        public required int PaymentDeadlineDays { get; set; }

        public ICollection<PackageService> PackageServices { get; set; } = new List<PackageService>();
        public ICollection<PackageActivity> PackageActivities { get; set; } = new List<PackageActivity>();
        public ICollection<PackageHotel> PackageHotels { get; set; } = new List<PackageHotel>();
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public ICollection<WaitingList> WaitingLists { get; set; } = new List<WaitingList>();
    }
}
