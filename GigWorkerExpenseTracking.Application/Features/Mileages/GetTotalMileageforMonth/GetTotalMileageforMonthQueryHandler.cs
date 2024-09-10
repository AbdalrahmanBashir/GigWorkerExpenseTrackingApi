using AutoMapper;
using GigWorkerExpenseTracking.Application.Contracts;
using GigWorkerExpenseTracking.Application.DTOs.MileagesDTOs;
using MediatR;

namespace GigWorkerExpenseTracking.Application.Features.Mileages.GetTotalMileageforMonth
{
    public class GetTotalMileageforMonthQueryHandler : IRequestHandler<GetTotalMileageforMonthQuery, MonthlyMileageReportDto>
    {
        private readonly IMileageRepository _mileageRepository;
        private readonly IMapper _mapper;

        public GetTotalMileageforMonthQueryHandler(IMileageRepository mileageRepository, IMapper mapper)
        {
            _mileageRepository = mileageRepository;
            _mapper = mapper;
        }

        public Task<MonthlyMileageReportDto> Handle(GetTotalMileageforMonthQuery request, CancellationToken cancellationToken)
        {
            var firstDayOfMonth = new DateTime(request.month.Year, request.month.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            var mileageWithinMonth = _mileageRepository.GetTotalMileageForMonth(firstDayOfMonth, lastDayOfMonth);
            var monthlyMileageReport = new MonthlyMileageReportDto
            {
               // TotalMileage = mileageWithinMonth
            };

            return default!; 
        }
    }
}
