using GigWorkerExpenseTracking.Application.DTOs.MileagesDTOs;
using MediatR;

namespace GigWorkerExpenseTracking.Application.Features.Mileages.GetTotalMileageforMonth
{
    public class GetTotalMileageforMonthQuery : IRequest<MonthlyMileageReportDto>
    {
        public DateTime month { get; set; }
    }
}
