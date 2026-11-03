namespace UmrahBookingSystem.Application.DTOs.Hotels
{
    public class UpdateHotelDto
    {
        public int Id { get; set; }
        public string HotelName { get; set; } = string.Empty;
        public int Stars { get; set; }
        public int CityId { get; set; }
        public string StreetName { get; set; } = string.Empty;
        public string? DoorNumber { get; set; }
        public string? PostalCode { get; set; }
    }
}