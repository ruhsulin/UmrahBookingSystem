using AutoMapper;
using UmrahBookingSystem.Application.Common.Results;
using UmrahBookingSystem.Application.DTOs.Hotels;
using UmrahBookingSystem.Application.Interfaces.Repositories;
using UmrahBookingSystem.Application.Interfaces.Services;

namespace UmrahBookingSystem.Application.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HotelService(IHotelRepository hotelRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<HotelDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var hotels = await _hotelRepository.GetAllWithCityAsync(cancellationToken);
            var hotelDtos = _mapper.Map<IEnumerable<HotelDto>>(hotels);
            return Result<IEnumerable<HotelDto>>.Success(hotelDtos);
        }

        public Task<Result<int>> CreateAsync(CreateHotelDto dto, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException(); 

        }
    }
}
