using GigWorkerExpenseTracking.Domain.Commons;
using GigWorkerExpenseTracking.Domain.ExpenseAggregate.ValueObjects;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigWorkerExpenseTracking.Domain.UserAggregate.ValueObjects
{
    public sealed class UserId : ValueObject
    {
        public Guid userId { get; }

        private UserId(Guid userId) {
            this.userId = userId;
        }
        public UserId()
        {
            
        }

        public static UserId CreateID()
        {
            return new(Guid.NewGuid());
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return new object[] { userId };
        }

        public static UserId CreateID(Guid? userId)
        {
            if (userId == null)
            {
                throw new ArgumentNullException(nameof(userId), "Guid value cannot be null.");
            }
            return new UserId(userId.Value);
        }
    }
}
