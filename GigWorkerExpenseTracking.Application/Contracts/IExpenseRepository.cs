using GigWorkerExpenseTracking.Domain.ExpenseAggregate.ValueObjects;
using GigWorkerExpenseTracking.Domain.ExpenseAggregate;
using GigWorkerExpenseTracking.Domain.UserAggregate.ValueObjects;
using GigWorkerExpenseTracking.Application.DTOs.ExpensesDTOs;
using GigWorkerExpenseTracking.Application.Models;

namespace GigWorkerExpenseTracking.Application.Contracts
{
    public interface IExpenseRepository
    {
        Task<Expense> GetByIdAsync(ExpenseId id); //
        Task<IEnumerable<ExpenseDto>> GetExpensesByUserAsync(UserId userId);//

        Task AddAsync(Expense expense);//
        Task UpdateAsync(Expense expense, UserId userId);
        Task DeleteAsync(ExpenseId id, UserId userId);

    }
}
