using GigWorkerExpenseTracking.Domain.Commons;

namespace GigWorkerExpenseTracking.Domain.ExpenseAggregate.ValueObjects
{
    public sealed class ExpenseItemId : ValueObject
    {
        public Guid expenseItemId { get; }

        private ExpenseItemId(Guid expenseItemId)
        {
            this.expenseItemId = expenseItemId;
        }


        public static ExpenseItemId CreateID() { 
            return new ExpenseItemId(Guid.NewGuid());
        }
       
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return new object[] { expenseItemId };
        }

        public static ExpenseItemId Create(Guid value)
        {
            return new ExpenseItemId(value);
        }
    }
}
