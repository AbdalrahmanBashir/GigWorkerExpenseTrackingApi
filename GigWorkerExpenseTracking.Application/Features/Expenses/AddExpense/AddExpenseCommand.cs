using GigWorkerExpenseTracking.Application.DTOs.ExpensesDTOs;
using GigWorkerExpenseTracking.Domain.ExpenseAggregate;
using GigWorkerExpenseTracking.Domain.UserAggregate.ValueObjects;
using MediatR;
using System.Net;

namespace GigWorkerExpenseTracking.Application.Features.Expenses.AddExpense
{
    public class AddExpenseCommand :IRequest<Expense>
    {
        public Guid userId { get; set; }
        public  AddExpenseDto? AddExpenseDto { get; set; }
    }
}
