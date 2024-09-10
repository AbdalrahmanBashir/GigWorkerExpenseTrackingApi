using AutoMapper;
using GigWorkerExpenseTracking.Application.Contracts;
using GigWorkerExpenseTracking.Application.DTOs.ExpensesDTOs;
using GigWorkerExpenseTracking.Domain.ExpenseAggregate.ValueObjects;
using MediatR;

namespace GigWorkerExpenseTracking.Application.Features.Expenses.ExpenseById
{
    public class ExpenseByIdQueryHandler : IRequestHandler<ExpenseByIdQuery, ExpenseDto>
    {
        private readonly IMapper _mapper;
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseByIdQueryHandler(IMapper mapper, IExpenseRepository expenseRepository)
        {
            _mapper = mapper;
            _expenseRepository = expenseRepository;
        }

        public async Task<ExpenseDto> Handle(ExpenseByIdQuery request, CancellationToken cancellationToken)
        {
            var expenseId = ExpenseId.Create(request.ExpenseId!);
         
            var expense = await _expenseRepository.GetByIdAsync(expenseId!);
           var mappedExpense= _mapper.Map<ExpenseDto>(expense);
            return mappedExpense!;
        }
    }
}
