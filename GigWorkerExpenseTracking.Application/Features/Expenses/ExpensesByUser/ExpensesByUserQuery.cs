using GigWorkerExpenseTracking.Application.DTOs.ExpensesDTOs;
using GigWorkerExpenseTracking.Application.DTOs.PagingsDTOs;
using GigWorkerExpenseTracking.Application.Models;
using MediatR;

namespace GigWorkerExpenseTracking.Application.Features.Expenses.ExpensesByUser
{
    public class ExpensesByUserQuery : IRequest<PagedResponse<ExpenseDto>>
    {
        
       public Guid? UserId { get; set; }
       public PagingDTO? paging { get; set;}
    }
}
