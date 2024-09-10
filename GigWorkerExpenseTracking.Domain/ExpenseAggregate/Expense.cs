using GigWorkerExpenseTracking.Domain.Commons;
using GigWorkerExpenseTracking.Domain.ExpenseAggregate.ValueObjects;
using GigWorkerExpenseTracking.Domain.UserAggregate.ValueObjects;
using System;

namespace GigWorkerExpenseTracking.Domain.ExpenseAggregate
{
    public class Expense : AggregateRoot<ExpenseId>
    {
        public UserId? UserId { get; private set; }
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime ActualDate { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime LastModifiedDate { get; private set; }

        private Expense()
            : base(default!)
        {
            // Default constructor for ORM frameworks
        }

        private Expense(ExpenseId id, UserId userId, string name, string description, decimal amount,DateTime actualDate, DateTime createdDate, DateTime lastModifiedDate)
            : base(id ?? ExpenseId.CreateID())
        {
            UserId = userId ?? throw new ArgumentNullException(nameof(userId));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Amount = amount;
            ActualDate = actualDate;
            CreatedDate = createdDate;
            LastModifiedDate = lastModifiedDate;
        }

        public Expense CreateExpense(UserId userId, string name, string description, decimal amount, DateTime actualDate)
        {
            var id = ExpenseId.CreateID();
            var createdDate = DateTime.UtcNow;
            var lastModifiedDate = createdDate;
            return new Expense(id, userId, name, description, amount, actualDate , createdDate, lastModifiedDate);
        }

        public void UpdateExpense(UserId userId, string name, string description)
        {
            UserId = userId ?? throw new ArgumentNullException(nameof(userId));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            LastModifiedDate = DateTime.UtcNow;
        }
    }
}
