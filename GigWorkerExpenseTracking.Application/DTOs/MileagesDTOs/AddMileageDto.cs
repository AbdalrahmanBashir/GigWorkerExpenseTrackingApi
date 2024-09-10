using GigWorkerExpenseTracking.Domain.UserAggregate.ValueObjects;

namespace GigWorkerExpenseTracking.Application.DTOs.MileagesDTOs
{
    public class AddMileageDto
    {
        public Guid? UserId { get;  set; }
        public DateTime LogDate { get;  set; }
        public decimal Distance { get;  set; }
    }
}
