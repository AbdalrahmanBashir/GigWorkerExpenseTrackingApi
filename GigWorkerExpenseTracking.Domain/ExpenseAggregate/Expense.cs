using GigWorkerExpenseTracking.Domain.Commons;
using GigWorkerExpenseTracking.Domain.ExpenseAggregate.Entities;
using GigWorkerExpenseTracking.Domain.ExpenseAggregate.ValueObjects;
using GigWorkerExpenseTracking.Domain.UserAggregate.ValueObjects;

namespace GigWorkerExpenseTracking.Domain.ExpenseAggregate
{
    public  class Expense : AggregateRoot<ExpenseId>
    { 
        public UserId? UserId { get;  set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        private decimal _totalAmount;
        private readonly List<ExpenseItem> _expenseItems = new();
        public decimal TotalAmount => _totalAmount;
        public IEnumerable<ExpenseItem> ExpenseItems => _expenseItems.AsReadOnly();

        private Expense() : base(default!)
        {
             // It's mainly used for ORM frameworks that require a parameterless constructor.
        }

       
        public Expense(ExpenseId? id = null, UserId userId = null!, string name = null!,string description = null!) : base(id! ?? ExpenseId.CreateID())
        {
         
            UserId = userId;
            Name = name;
            Description = description;
            
            RecalculateTotalAmount();
           // _totalAmount = _expenseItems.Sum(e => (decimal)e.Amount);
        }


        public Expense CreateExpense(UserId userId,   string name, string description)
        {
            var id = ExpenseId.CreateID();
            var newExpense = new Expense(id, userId, name, description);
            return newExpense;
        }


        public ExpenseItem AddItem(ExpenseId expenseId, decimal amount, string description)
        {

            var newItem = ExpenseItem.CreateItem(expenseId, amount,  description);
            _expenseItems.Add(newItem);
            RecalculateTotalAmount();
            return newItem;
        }


        public void DeleteItem(Decimal amount, DateTime Date, string Description)
        {

            var existingItem = _expenseItems.FirstOrDefault(e => e.Date == Date && e.Amount == amount && e.Description == Description);

            if (existingItem is null)
            {
                throw new ArgumentException("Expense not found.");
            }
            _expenseItems.Remove(existingItem);
            RecalculateTotalAmount();
        }

        private void RecalculateTotalAmount()
        {
           // _totalAmount = _expenseItems.Sum(e => (decimal)e.Amount);
        }

    }
}
