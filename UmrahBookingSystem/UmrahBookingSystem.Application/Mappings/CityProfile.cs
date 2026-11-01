using AutoMapper;
using UmrahBookingSystem.Application.DTOs.Cities;
using UmrahBookingSystem.Domain.Entities;

namespace UmrahBookingSystem.Application.Mappings
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityDto>();
        }
    }
}
