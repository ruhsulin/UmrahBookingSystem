using UmrahBookingSystem.Domain.Common;

namespace UmrahBookingSystem.Domain.Entities
{
    public class Package : BaseEntity
    {
        public int Id { get; set; }
        public string PackageName { get; set; } = null!;
        public DateTime DepartureDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime DepartureTime { get; set; }
        public int MaxPassenger { get; set; }
        public int BaggageAllowance { get; set; }
        public string Description { get; set; } = null!;
        public string CoverImageUrl { get; set; } = null!;
        public decimal BasePrice { get; set; } 
        public string DepartureAirport { get; set; } = null!;
        public string ArrivalAirport { get; set; } = null!;
        public string? TransitAirport { get; set; }
        public string AirlineName { get; set; } = null!;

        public string DepartureFlightNumber { get; set; } = null!;
        public string ReturnFlightNumber { get; set; } = null!;
        public DateTime ReturnTime { get; set; }
        public int AvailableSpots { get; set; }
        public int PaymentDeadlineDays { get; set; }

        public ICollection<PackageService> PackageServices { get; set; } = new List<PackageService>();
        public ICollection<PackageActivity> PackageActivities { get; set; } = new List<PackageActivity>();
        public ICollection<PackageHotel> PackageHotels { get; set; } = new List<PackageHotel>();
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public ICollection<WaitingList> WaitingLists { get; set; } = new List<WaitingList>();
    }
}
