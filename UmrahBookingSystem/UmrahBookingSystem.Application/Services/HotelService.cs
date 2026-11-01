using AutoMapper;
using UmrahBookingSystem.Application.Common.Results;
using UmrahBookingSystem.Application.DTOs.Hotels;
using UmrahBookingSystem.Application.Interfaces.Repositories;
using UmrahBookingSystem.Application.Interfaces.Services;
using UmrahBookingSystem.Domain.Entities;

namespace UmrahBookingSystem.Application.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICityRepository _cityRepository;

        public HotelService(IHotelRepository hotelRepository, ICityRepository cityRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _cityRepository = cityRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<HotelDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var hotels = await _hotelRepository.GetAllWithCityAsync(cancellationToken);
            var hotelDtos = _mapper.Map<IEnumerable<HotelDto>>(hotels);
            return Result<IEnumerable<HotelDto>>.Success(hotelDtos);
        }

        public async Task<Result<int>> CreateAsync(CreateHotelDto dto, CancellationToken cancellationToken = default)
        {
            var errors = new List<Error>();

            if(string.IsNullOrWhiteSpace(dto.HotelName))
                errors.Add(new Error("Hotel.NameRequired", "Hotel name is required."));
            

            if(dto.Stars < 1 || dto.Stars > 5)
                errors.Add(new Error("Hotel.StarsOutOfRange", "Hotel stars must be between 1 and 5."));
            

            if(dto.CityId <=0)
                errors.Add(new Error("Hotel.CityRequired", "City is required."));
              

            if (string.IsNullOrWhiteSpace(dto.StreetName))
                errors.Add(new Error("Hotel.StreetRequired", "Street name is required."));
            

            if(errors.Count > 0)
                return Result<int>.Failure(errors.ToArray());

            var city = await _cityRepository.GetByIdAsync(dto.CityId, cancellationToken);
            if (city is null)
                return Result<int>.Failure(Error.NotFound("City"));

            var hotel = new Hotel
            {
                HotelName = dto.HotelName.Trim(),
                Stars = dto.Stars,
                Location = new Location
                {
                    CityId = dto.CityId,
                    StreetName = dto.StreetName.Trim(),
                    DoorNumber = dto.DoorNumber?.Trim(),
                    PostalCode = dto.PostalCode?.Trim()
                }
            };

            await _hotelRepository.InsertAsync(hotel, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<int>.Success(hotel.Id);
        }
    }
}
