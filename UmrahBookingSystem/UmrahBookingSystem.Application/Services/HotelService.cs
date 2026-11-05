using AutoMapper;
using UmrahBookingSystem.Application.Common.Errors;
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
            var errors = ValidateHotelInput(dto.HotelName, dto.Stars, dto.CityId, dto.StreetName);

            if (errors.Count > 0)
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

        public async Task<Result<UpdateHotelDto>> GetForEditAsync(int id, CancellationToken cancellationToken = default)
        {
            var hotel = await _hotelRepository.GetByIdWithLocationAsync(id, cancellationToken);
            if (hotel is null)
                return Result<UpdateHotelDto>.Failure(HotelErrors.NotFound);

            return Result<UpdateHotelDto>.Success(_mapper.Map<UpdateHotelDto>(hotel));
        }

        public async Task<Result<int>> UpdateAsync(UpdateHotelDto dto, CancellationToken cancellationToken = default)
        {
            var errors = ValidateHotelInput(dto.HotelName, dto.Stars, dto.CityId, dto.StreetName);
            if (errors.Count > 0)
                return Result<int>.Failure(errors.ToArray());

            // The Id comes from a hidden form field: user input, so verify it.
            var hotel = await _hotelRepository.GetByIdWithLocationAsync(dto.Id, cancellationToken);
            if (hotel is null)
                return Result<int>.Failure(HotelErrors.NotFound);

            var city = await _cityRepository.GetByIdAsync(dto.CityId, cancellationToken);
            if (city is null)
                return Result<int>.Failure(Error.NotFound("City"));

            hotel.HotelName = dto.HotelName.Trim();
            hotel.Stars = dto.Stars;
            hotel.Location.CityId = dto.CityId;
            hotel.Location.StreetName = dto.StreetName.Trim();
            hotel.Location.DoorNumber = dto.DoorNumber?.Trim();
            hotel.Location.PostalCode = dto.PostalCode?.Trim();

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<int>.Success(hotel.Id);
        }

        public async Task<Result<int>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var hotel = await _hotelRepository.GetByIdWithLocationAsync(id, cancellationToken);
            if (hotel is null)
                return Result<int>.Failure(HotelErrors.NotFound);

            if (await _hotelRepository.IsUsedInPackageAsync(id, cancellationToken))
                return Result<int>.Failure(HotelErrors.InUse);

            _hotelRepository.DeleteWithLocation(hotel);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<int>.Success(id);
        }

        private static List<Error> ValidateHotelInput(string hotelName, int stars, int cityId, string streetName)
        {
            var errors = new List<Error>();

            if (string.IsNullOrWhiteSpace(hotelName))
                errors.Add(HotelErrors.NameRequired);

            if (stars < 1 || stars > 5)
                errors.Add(HotelErrors.StarsOutOfRange);

            if (cityId <= 0)
                errors.Add(HotelErrors.CityRequired);

            if (string.IsNullOrWhiteSpace(streetName))
                errors.Add(HotelErrors.StreetRequired);

            return errors;
        }
    }
}