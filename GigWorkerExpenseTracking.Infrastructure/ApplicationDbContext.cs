using GigWorkerExpenseTracking.Domain.ExpenseAggregate;
using GigWorkerExpenseTracking.Domain.ExpenseAggregate.Entities;
using GigWorkerExpenseTracking.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace GigWorkerExpenseTracking.Infrastructure
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);


        }

        public DbSet<User> Users { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        // public DbSet<ExpenseItem> ExpenseItems { get; set; }
        //public DbSet<Mileage> Mileages { get; set; }

    }
}
