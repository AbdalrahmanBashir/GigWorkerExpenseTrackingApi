using GigWorkerExpenseTracking.Domain.ExpenseAggregate.ValueObjects;

namespace GigWorkerExpenseTracking.Application.DTOs.ExpensesDTOs
{
    public class ExpenseItemDto
    {
        public ExpenseItemId? ExpenseItemId { get; set; }
        public ExpenseId? ExpenseId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
    }
}