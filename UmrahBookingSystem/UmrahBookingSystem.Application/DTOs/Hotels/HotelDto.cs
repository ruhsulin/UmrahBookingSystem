namespace UmrahBookingSystem.Application.DTOs.Hotels
{
    public class HotelDto
    {
        public int Id { get; set; }
        public string HotelName { get; set; } = string.Empty;
        public int Stars { get; set; }
        public string CityName { get; set; } = string.Empty;
        public string? ThumbnailUrl { get; set; }  
    }
}
