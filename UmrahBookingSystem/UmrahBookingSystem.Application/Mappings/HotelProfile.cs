using AutoMapper;
using UmrahBookingSystem.Application.DTOs.Hotels;
using UmrahBookingSystem.Domain.Entities;

namespace UmrahBookingSystem.Application.Mappings
{
    public class HotelProfile : Profile
    {
        public HotelProfile()
        {
            CreateMap<Hotel, HotelDto>()
                .ForMember(dest=> dest.CityName,
                              opt => opt.MapFrom(src => src.Location.City.CityName));
        }   
    }
}
