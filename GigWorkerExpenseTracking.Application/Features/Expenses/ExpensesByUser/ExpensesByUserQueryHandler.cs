using AutoMapper;
using GigWorkerExpenseTracking.Application.Contracts;
using GigWorkerExpenseTracking.Application.DTOs.ExpensesDTOs;
using GigWorkerExpenseTracking.Domain.UserAggregate.ValueObjects;
using MediatR;
using System.Linq.Expressions;

namespace GigWorkerExpenseTracking.Application.Features.Expenses.ExpensesByUser
{
    public class ExpensesByUserQueryHandler : IRequestHandler<ExpensesByUserQuery, IEnumerable<ExpenseDto>>
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IMapper _mapper;

        public ExpensesByUserQueryHandler(IExpenseRepository expenseRepository, IMapper mapper)
        {
            _expenseRepository = expenseRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExpenseDto>> Handle(ExpensesByUserQuery request, CancellationToken cancellationToken)
        {  

            if (request.UserId! == null!)
            {
                throw new ArgumentNullException(nameof(request.UserId), "User ID cannot be null.");
            }

            var userId = UserId.CreateID(request.UserId!);

            var expenses = await _expenseRepository.GetExpensesByUserAsync(userId);

            if (expenses == null)
            {
                throw new ArgumentNullException(nameof(expenses), "Expenses cannot be null.");
            }

            var expensesDto = _mapper.Map<IEnumerable<ExpenseDto>>(expenses);
            //return expenses;
            return expensesDto;
            
        }

    }
}
