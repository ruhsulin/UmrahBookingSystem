using AutoMapper;
using UmrahBookingSystem.Application.Common.Results;
using UmrahBookingSystem.Application.DTOs.Cities;
using UmrahBookingSystem.Application.Interfaces.Repositories;
using UmrahBookingSystem.Application.Interfaces.Services;

namespace UmrahBookingSystem.Application.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CityService(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<CityDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var cities = await _cityRepository.GetAllAsync(cancellationToken);
            var cityDtos = _mapper.Map<IEnumerable<CityDto>>(cities);

            return Result<IEnumerable<CityDto>>.Success(cityDtos);
        }



    }
}
