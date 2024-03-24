using GigWorkerExpenseTracking.Application.DTOs.ExpensesDTOs;
using GigWorkerExpenseTracking.Domain.UserAggregate.ValueObjects;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace GigWorkerExpenseTracking.Application.Features.Expenses.ExpensesByUser
{
    public class ExpensesByUserQuery : IRequest<IEnumerable<ExpenseDto>>
    {
        [Required]
       public Guid? UserId { get; set; }
    }
}
