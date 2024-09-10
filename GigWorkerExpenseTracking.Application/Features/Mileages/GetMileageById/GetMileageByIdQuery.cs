using GigWorkerExpenseTracking.Application.DTOs.MileagesDTOs;
using MediatR;

namespace GigWorkerExpenseTracking.Application.Features.Mileages.GetMileageById
{
    public class GetMileageByIdQuery : IRequest<MileageDto>
    {
        public Guid? MileageId { get; set; }
    }
}
