using System;
using System.Collections.Generic;
using System.Text;

namespace UmrahBookingSystem.Domain.Entities
{
    public class Package
    {
        public int Id { get; set; }
        public required string PackageName { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public TimeOnly DepartureTime { get; set; }
        public int MaxPassanger { get; set; }
        public int BaggageAllowance { get; set; }
        public ICollection<PackageService> PackageServices { get; set; } = new List<PackageService>();
        public ICollection<PackageActivity> PackageActivities { get; set; } = new List<PackageActivity>();
        public ICollection<PackageHotel> PackageHotels { get; set; } = new List<PackageHotel>();
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
