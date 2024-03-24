using GigWorkerExpenseTracking.Application.DTOs.ExpenseItemDTOs;
using GigWorkerExpenseTracking.Application.DTOs.ExpensesDTOs;
using GigWorkerExpenseTracking.Domain.ExpenseAggregate;
using GigWorkerExpenseTracking.Domain.ExpenseAggregate.ValueObjects;
using GigWorkerExpenseTracking.Domain.UserAggregate.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigWorkerExpenseTracking.Application.Features.Expenses.AddExpenseItem
{
    public class AddExpenseItemCommand : IRequest<Guid>
    {
       
        public AddExpenseItemDto? AddExpenseItemDto { get; set; }
    }
}
