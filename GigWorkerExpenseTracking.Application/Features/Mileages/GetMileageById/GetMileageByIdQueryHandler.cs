using AutoMapper;
using GigWorkerExpenseTracking.Application.Contracts;
using GigWorkerExpenseTracking.Application.DTOs.MileagesDTOs;
using GigWorkerExpenseTracking.Domain.MileageAggregate.ValueObjects;
using MediatR;

namespace GigWorkerExpenseTracking.Application.Features.Mileages.GetMileageById
{
    public class GetMileageByIdQueryHandler : IRequestHandler<GetMileageByIdQuery, MileageDto>
    {
        private readonly IMileageRepository _mileageRepository;
        private readonly IMapper _mapper;

        public GetMileageByIdQueryHandler(IMileageRepository mileageRepository, IMapper mapper)
        {
            _mileageRepository = mileageRepository;
            _mapper = mapper;
        }

        public Task<MileageDto> Handle(GetMileageByIdQuery request, CancellationToken cancellationToken)
        {
           var mileageId = MileageId.ConvertId(request.MileageId!.Value);

            var mileage = _mileageRepository.GetByIdAsync(mileageId);

            var mileageDto = _mapper.Map<MileageDto>(mileage);

            return Task.FromResult(mileageDto);
        }
    }
}
