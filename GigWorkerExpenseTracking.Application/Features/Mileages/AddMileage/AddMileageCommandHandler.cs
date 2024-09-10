using AutoMapper;
using GigWorkerExpenseTracking.Application.Contracts;
using GigWorkerExpenseTracking.Domain.MileageAggregate;
using MediatR;

namespace GigWorkerExpenseTracking.Application.Features.Mileages.AddMileage
{
    public class AddMileageCommandHandler : IRequestHandler<AddMileageCommand, Guid>
    {
        private readonly IMileageRepository _mileageRepository;
        private readonly IMapper _mapper;

        public AddMileageCommandHandler(IMileageRepository mileageRepository, IMapper mapper)
        {
            _mileageRepository = mileageRepository;
            _mapper = mapper;
        }

        public Task<Guid> Handle(AddMileageCommand request, CancellationToken cancellationToken)
        {
            var mileage = _mapper.Map<Mileage>(request.AddMileageDto);
           
            var newMileage = mileage.CreateMileage(
                mileage.UserId,
                mileage.LogDate,
                mileage.Distance
                );
            try
            {
                _mileageRepository.AddAsync(newMileage);

                return Task.FromResult(newMileage.Id!.Value);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

           
        }
    }
}
