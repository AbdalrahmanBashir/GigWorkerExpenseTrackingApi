using GigWorkerExpenseTracking.Domain.Commons;
using System.ComponentModel.DataAnnotations;

namespace GigWorkerExpenseTracking.Domain.ExpenseAggregate.ValueObjects
{
    public sealed class ExpenseId : ValueObject
    {
       
        public Guid expenseId { get; }

        private ExpenseId(Guid expenseId)
        {
            this.expenseId = expenseId;
        }
   

        public static ExpenseId CreateID()
        { 
            return new ExpenseId(Guid.NewGuid());
        }
          
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return new object[] { expenseId };
        }

        public static ExpenseId Create(Guid? value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), "Guid value cannot be null.");
            }
            return new ExpenseId(value.Value);
        }
    }
}
