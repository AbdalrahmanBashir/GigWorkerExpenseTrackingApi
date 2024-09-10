using GigWorkerExpenseTracking.Application.DTOs.MileagesDTOs;
using MediatR;

namespace GigWorkerExpenseTracking.Application.Features.Mileages.AddMileage
{
    public class AddMileageCommand : IRequest<Guid>
    {
        public AddMileageDto? AddMileageDto { get; set; }
    }
}
