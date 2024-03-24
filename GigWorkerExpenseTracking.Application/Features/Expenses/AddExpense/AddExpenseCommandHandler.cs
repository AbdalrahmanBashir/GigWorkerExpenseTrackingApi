using AutoMapper;
using GigWorkerExpenseTracking.Application.Contracts;
using GigWorkerExpenseTracking.Domain.ExpenseAggregate;
using MediatR;

namespace GigWorkerExpenseTracking.Application.Features.Expenses.AddExpense
{
    public class AddExpenseCommandHandler : IRequestHandler<AddExpenseCommand, Expense>
    {
        private readonly IMapper _mapper;
        private readonly IExpenseRepository _expenseRepository;

        public AddExpenseCommandHandler(IMapper mapper, IExpenseRepository expenseRepository)
        {
            _mapper = mapper;
            _expenseRepository = expenseRepository;
        }
        public async Task<Expense> Handle(AddExpenseCommand request, CancellationToken cancellationToken)
        {
            
           var expense = _mapper.Map<Expense>(request.AddExpenseDto);
         
           var newExpense =  expense.CreateExpense(

              expense.UserId!,
              expense.Name,
              expense.Description
              );

            await _expenseRepository.AddAsync(newExpense);
            return newExpense;
        }
    }
}
