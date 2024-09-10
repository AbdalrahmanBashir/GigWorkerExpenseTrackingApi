using GigWorkerExpenseTracking.Domain.UserAggregate.ValueObjects;

namespace GigWorkerExpenseTracking.Application.DTOs.MileagesDTOs
{
    public class MileageDto
    {
        public Guid? UserId { get;  set; }
        public DateTime LogDate { get;  set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public decimal Distance { get; set; }
    }
}
