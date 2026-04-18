using AutoMapper;
using UmrahBookingSystem.Application.DTOs.Bookings;
using UmrahBookingSystem.Domain.Entities;

namespace UmrahBookingSystem.Application.Mappings
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, BookingDto>();
        }
    }
}
