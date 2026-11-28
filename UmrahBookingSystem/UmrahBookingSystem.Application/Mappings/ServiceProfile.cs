using AutoMapper;
using UmrahBookingSystem.Application.DTOs.Services;
using UmrahBookingSystem.Domain.Entities;

namespace UmrahBookingSystem.Application.Mappings
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<Service, ServiceDto>();
            CreateMap<Service, UpdateServiceDto>();
        }
    }
}
