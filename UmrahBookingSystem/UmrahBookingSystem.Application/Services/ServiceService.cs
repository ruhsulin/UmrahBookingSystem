using AutoMapper;
using UmrahBookingSystem.Application.Common.Errors;
using UmrahBookingSystem.Application.Common.Results;
using UmrahBookingSystem.Application.DTOs.Services;
using UmrahBookingSystem.Application.Interfaces.Repositories;
using UmrahBookingSystem.Application.Interfaces.Services;
using UmrahBookingSystem.Domain.Entities;

namespace UmrahBookingSystem.Application.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private const int MaxNameLength = 250;

        public ServiceService(IServiceRepository serviceRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<ServiceDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var services = await _serviceRepository.GetAllAsync(cancellationToken);
            var dtos = _mapper.Map<IEnumerable<ServiceDto>>(services);

            return Result<IEnumerable<ServiceDto>>.Success(dtos);
        }

        public async Task<Result<UpdateServiceDto>> GetForEditAsync(int id, CancellationToken cancellationToken = default)
        {
            var service = await _serviceRepository.GetByIdAsync(id, cancellationToken);
            if (service is null)
                return Result<UpdateServiceDto>.Failure(ServiceErrors.NotFound);

            return Result<UpdateServiceDto>.Success(_mapper.Map<UpdateServiceDto>(service));
        }

        public async Task<Result<int>> CreateAsync(CreateServiceDto dto, CancellationToken cancellationToken = default)
        {
            var name = dto.ServiceName?.Trim() ?? string.Empty;

            var errors = ValidateServiceInput(name);
            if (errors.Count > 0)
                return Result<int>.Failure(errors.ToArray());

            if (await _serviceRepository.NameExistsAsync(name, null, cancellationToken))
                return Result<int>.Failure(ServiceErrors.DuplicateName);

            var service = new Service { ServiceName = name };

            await _serviceRepository.InsertAsync(service, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<int>.Success(service.Id);
        }

        public async Task<Result<int>> UpdateAsync(UpdateServiceDto dto, CancellationToken cancellationToken = default)
        {
            var name = dto.ServiceName?.Trim() ?? string.Empty;

            var errors = ValidateServiceInput(name);
            if (errors.Count > 0)
                return Result<int>.Failure(errors.ToArray());

            var service = await _serviceRepository.GetByIdAsync(dto.Id, cancellationToken);
            if (service is null)
                return Result<int>.Failure(ServiceErrors.NotFound);

            if (await _serviceRepository.NameExistsAsync(name, dto.Id, cancellationToken))
                return Result<int>.Failure(ServiceErrors.DuplicateName);

            service.ServiceName = name;

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<int>.Success(service.Id);
        }

        public async Task<Result<int>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var service = await _serviceRepository.GetByIdAsync(id, cancellationToken);
            if (service is null)
                return Result<int>.Failure(ServiceErrors.NotFound);

            if (await _serviceRepository.IsUsedInPackageAsync(id, cancellationToken))
                return Result<int>.Failure(ServiceErrors.InUse);

            _serviceRepository.Delete(service);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<int>.Success(service.Id);
        }

        private static List<Error> ValidateServiceInput(string serviceName)
        {
            var errors = new List<Error>();

            if (string.IsNullOrWhiteSpace(serviceName))
                errors.Add(ServiceErrors.NameRequired);
            else if (serviceName.Length > MaxNameLength)
                errors.Add(ServiceErrors.NameTooLong);

            return errors;
        }
    }
}