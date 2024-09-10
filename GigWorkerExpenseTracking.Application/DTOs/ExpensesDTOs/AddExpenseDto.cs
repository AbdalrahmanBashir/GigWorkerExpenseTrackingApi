using GigWorkerExpenseTracking.Domain.UserAggregate.ValueObjects;

namespace GigWorkerExpenseTracking.Application.DTOs.ExpensesDTOs
{
    public class AddExpenseDto
    {
        public Guid? UserId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public decimal? Amount { get; set; }
        public DateTime? ActualDate { get; set; }
        
    }
}
