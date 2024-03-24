using GigWorkerExpenseTracking.Application.Contracts;
using GigWorkerExpenseTracking.Domain.ExpenseAggregate;
using GigWorkerExpenseTracking.Domain.ExpenseAggregate.Entities;
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

        public async Task AddExpenseItemAsync(ExpenseItem expense)
        {


            _context.Add(expense);
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
                    .Include(e => e.ExpenseItems)
                    .AsNoTracking()
                    .Where(e => e.Id == ExpenseId)
                    .Select(e => new Expense
                    (
                        e.Id,
                        e.UserId,
                        e.Name,
                        e.Description
                    ))
                    .FirstOrDefaultAsync();

                return expense;
            }
            catch (Exception ex)
            {
                 throw new Exception(ex.Message);
            }
            
        }


        public async Task<IEnumerable<Expense>> GetExpensesByUserAsync(UserId userId)
        {
            try
            {
                var expenses = await _context.Expenses
                    .Include(e => e.ExpenseItems)
                    .AsNoTracking()
                    .Where(e => e.UserId! == userId)
                    .ToListAsync();
                    
                return expenses;

               /* var expense = await _context.Expenses
                    .Where(e => e.UserId! == userId)
                    //.Include(e => e.ExpenseItems)
                    .AsNoTracking()
                    .Select(e => new ExpenseDto
                    {
                        ExpenseId = e.Id,
                        userId = e.UserId,
                        Name = e.Name,
                        Description = e.Description,
                        ExpenseItems =e.ExpenseItems
                        .Select(it => new ExpenseItemDto
                        {
                            ExpenseItemId = it.Id,
                            Description = it.Description,
                            Date = it.Date,
                            Amount = it.Amount
                        }).ToList()

                    }).ToListAsync();
       
                return expense;*/
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Exception: {ex.Message}");
                throw new Exception("An error occurred while retrieving the expense. See inner exception for details.", ex);
            }

        }


        public async Task RemoveExpenseItemAsync(ExpenseItem expenseItem)
        {
           _context.Remove(expenseItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Expense expense, UserId userId)
        {
            _context.Entry(expense).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }


        

    }
}
