using AutoMapper;
using GigWorkerExpenseTracking.Application.Contracts;
using GigWorkerExpenseTracking.Domain.ExpenseAggregate;
using GigWorkerExpenseTracking.Domain.ExpenseAggregate.Entities;
using GigWorkerExpenseTracking.Domain.ExpenseAggregate.ValueObjects;
using GigWorkerExpenseTracking.Domain.UserAggregate.ValueObjects;
using MediatR;

namespace GigWorkerExpenseTracking.Application.Features.Expenses.AddExpenseItem
{
    public class AddExpenseItemCommandHandler : IRequestHandler<AddExpenseItemCommand, Guid>
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IMapper _mapper;

        public AddExpenseItemCommandHandler(IExpenseRepository expenseRepository, IMapper mapper)
        {
            _expenseRepository = expenseRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(AddExpenseItemCommand request, CancellationToken cancellationToken)
        {
           
            var expenseId = ExpenseId.Create(request.AddExpenseItemDto!.ExpenseId!);
            
            var existingExpense = await _expenseRepository.GetByIdAsync(expenseId);
         
            if (existingExpense! == null!)
            {
                throw new ArgumentNullException($"Expense with ID {request.AddExpenseItemDto.ExpenseId} not found.");
            }


            var newItem = existingExpense.AddItem(
             expenseId,
             request.AddExpenseItemDto!.Amount,
             request.AddExpenseItemDto!.Description!
                );
        
            //var newExpenseItem = _mapper.Map<ExpenseItem>(newItem);

            try
            {
                await _expenseRepository.AddExpenseItemAsync(newItem);
            }
            catch
            {
                throw;
            }

            
            return newItem.Id!.expenseItemId;
        }
    }
}
