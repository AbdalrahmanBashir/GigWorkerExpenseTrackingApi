using GigWorkerExpenseTracking.Domain.Commons;
using GigWorkerExpenseTracking.Domain.ExpenseAggregate.ValueObjects;



namespace GigWorkerExpenseTracking.Domain.ExpenseAggregate.Entities
{
    public sealed class ExpenseItem : Entity<ExpenseItemId>
    {
        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; }
        public string Description { get; private set; }
        public ExpenseId ExpenseId { get; set; }


       // public ExpenseItemId ExpenseItemId => _expenseItemId;

        private ExpenseItem() : base(default)
        {

        }

        private ExpenseItem(ExpenseItemId expenseItemId, ExpenseId expenseId, string description,  decimal amount) : base(expenseItemId)
        {
            ExpenseId = expenseId;
            Description = description;
            Amount = amount;
        }


        internal static ExpenseItem CreateItem(ExpenseId ExpenseId, decimal amount, string description)
        {
            ValidateAmountAndDate(amount, description);
            var id = ExpenseItemId.CreateID();

            return new ExpenseItem(id, ExpenseId, description, amount)
            {
                Date = DateTime.Today
            };
        }

        internal static void ValidateAmountAndDate(decimal amount, string description)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be positive.", nameof(amount));
            }


            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException(nameof(description));
            }
        }


       
    }

    
}
