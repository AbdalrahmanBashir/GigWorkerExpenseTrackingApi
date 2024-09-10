using GigWorkerExpenseTracking.Application.DTOs.ExpensesDTOs;
using MediatR;

namespace GigWorkerExpenseTracking.Application.Features.Expenses.ExpenseById
{
    public class ExpenseByIdQuery : IRequest<ExpenseDto>
    {
        public Guid? ExpenseId { get; set; }

    }
}
