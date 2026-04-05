using UmrahBookingSystem.Domain.Common;

namespace UmrahBookingSystem.Domain.Entities
{
    public class Passenger : BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string PassportNumber { get; set; } = null!;
        public DateTime PassportExpiryDate { get; set; }
        public string PassportImageUrl { get; set; } = null!;
        public string PersonalPhotoUrl { get; set; } = null!;
        public string VerificationStatus { get; set; } = null!;
        public string? VerificationNote { get; set; }
        public int? GuardianId { get; set; }
        public int BookingId { get; set; }

        public Passenger? Guardian { get; set; } 
        public Booking Booking { get; set; } = null!;
    }
}
