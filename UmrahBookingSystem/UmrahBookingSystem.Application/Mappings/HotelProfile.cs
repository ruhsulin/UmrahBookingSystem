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

            CreateMap<Hotel, UpdateHotelDto>()
               .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.Location.CityId))
               .ForMember(dest => dest.StreetName, opt => opt.MapFrom(src => src.Location.StreetName))
               .ForMember(dest => dest.DoorNumber, opt => opt.MapFrom(src => src.Location.DoorNumber))
               .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.Location.PostalCode));
        }   
    }
}
