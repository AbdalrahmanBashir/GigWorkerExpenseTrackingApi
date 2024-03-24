using GigWorkerExpenseTracking.Domain.Commons;
using GigWorkerExpenseTracking.Domain.MileageAggregate.ValueObjects;
using GigWorkerExpenseTracking.Domain.UserAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigWorkerExpenseTracking.Domain.MileageAggregate
{
    public  class Mileage : AggregateRoot<MileageId>
    {
        public UserId? UserId { get; private set; }
        public DateTime LogDate { get; private set; }
        public decimal Distance { get; private set; }
        public Mileage(MileageId id, UserId? userId, DateTime logDate, decimal distance) : base(id)
        {
            UserId = userId ?? throw new ArgumentNullException(nameof(userId));
            LogDate = logDate;
            Distance = distance;
        }
        private Mileage(MileageId id) : base(id)
        {

        }
    }
}
