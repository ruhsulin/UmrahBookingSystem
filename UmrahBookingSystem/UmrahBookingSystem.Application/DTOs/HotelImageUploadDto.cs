namespace UmrahBookingSystem.Application.DTOs.Hotels
{
    // Stream, not IFormFile: Application must not depend on ASP.NET (UBS-51 decision).
    public sealed record HotelImageUploadDto(Stream Content, string FileName);
}