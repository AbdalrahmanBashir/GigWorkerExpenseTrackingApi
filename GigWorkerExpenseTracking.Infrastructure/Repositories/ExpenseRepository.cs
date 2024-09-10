using GigWorkerExpenseTracking.Application.Contracts;
using GigWorkerExpenseTracking.Application.DTOs.ExpensesDTOs;
using GigWorkerExpenseTracking.Domain.ExpenseAggregate;
using GigWorkerExpenseTracking.Domain.ExpenseAggregate.ValueObjects;
using GigWorkerExpenseTracking.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace GigWorkerExpenseTracking.Infrastructure.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ApplicationDbContext _context;

        public ExpenseRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddAsync(Expense expense)
        {
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(ExpenseId id, UserId userId)
        {
            var expense = await _context.Expenses
                .SingleAsync(e => e.Id! == id && e.UserId! == userId);

            _context.Expenses.Remove(expense);

            await _context.SaveChangesAsync();
        }

        public async Task<Expense> GetByIdAsync(ExpenseId ExpenseId)
        {
            try
            {

                var expense = await _context.Expenses
                    .AsNoTracking()
                    .Where(e => e.Id! == ExpenseId)
                    .FirstOrDefaultAsync();

                return expense!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<IEnumerable<ExpenseDto>> GetExpensesByUserAsync(UserId userId)
        {
            try
                
            {
                var expenses = await _context.Expenses
                    .Where(e => e.UserId! == userId)
                    .Select(e => new ExpenseDto
                    {
                        ExpenseId = e.Id!.expenseId.ToString(),
                        userId = e.UserId!.userId.ToString(),
                        Name = e.Name,
                        Description = e.Description,
                        Amount = e.Amount,
                        ActualDate = e.ActualDate,
                        CreatedDate = e.CreatedDate,
                        LastModifiedDate = e.LastModifiedDate
                        

                    }).ToListAsync();

                return expenses;
                

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Exception: {ex.Message}");
                throw new Exception("An error occurred while retrieving the expense. See inner exception for details.", ex);
            }

        }

        public async Task UpdateAsync(Expense expense, UserId userId)
        {
            _context.Entry(expense).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }
}
