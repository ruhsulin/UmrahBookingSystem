using UmrahBookingSystem.Domain.Enums;

namespace UmrahBookingSystem.Domain.Entities
{
    public class Passenger
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public required string PassportNumber { get; set; }
        public required DateTime PassportExpiryDate { get; set; }
        public required string PassportImageUrl { get; set; }
        public required string PersonalPhotoUrl { get; set; }
        public required VerificationStatus VerificationStatus { get; set; }
        public string? VerificationNote { get; set; }
        public int? GuardianId { get; set; }
        public required int BookingId { get; set; }

        public Passenger? Guardian { get; set; } 
        public Booking Booking { get; set; } = null!;

    }
}
