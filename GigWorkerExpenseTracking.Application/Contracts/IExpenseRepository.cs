using GigWorkerExpenseTracking.Domain.ExpenseAggregate.ValueObjects;
using GigWorkerExpenseTracking.Domain.ExpenseAggregate;
using GigWorkerExpenseTracking.Domain.UserAggregate.ValueObjects;
using System.Threading.Tasks;
using GigWorkerExpenseTracking.Domain.ExpenseAggregate.Entities;
using GigWorkerExpenseTracking.Application.DTOs.ExpensesDTOs;

namespace GigWorkerExpenseTracking.Application.Contracts
{
    public interface IExpenseRepository
    {
        Task<Expense> GetByIdAsync(ExpenseId id); //
        Task<IEnumerable<Expense>> GetExpensesByUserAsync(UserId userId);//

        Task AddAsync(Expense expense);//
        Task UpdateAsync(Expense expense, UserId userId);
        Task DeleteAsync(ExpenseId id, UserId userId);

        Task AddExpenseItemAsync(ExpenseItem expense); //
        Task RemoveExpenseItemAsync(ExpenseItem expenseItem);
    }
}
