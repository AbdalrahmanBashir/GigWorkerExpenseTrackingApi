using System.ComponentModel.DataAnnotations;

namespace GigWorkerExpenseTracking.Application.DTOs.ExpenseItemDTOs
{
    public class AddExpenseItemDto
    {
        [Required]
        public Guid? UserId { get; set; }
        [Required]
        public Guid? ExpenseId { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string? Description { get; set; }
    }
}
