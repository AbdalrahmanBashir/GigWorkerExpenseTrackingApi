using GigWorkerExpenseTracking.Domain.Commons;

namespace GigWorkerExpenseTracking.Domain.MileageAggregate.ValueObjects
{
    public sealed class MileageId : ValueObject
    {
        public Guid Value { get; }

        private MileageId(Guid value)
        {
            Value = value;
        }
        public static MileageId New() => new MileageId(Guid.NewGuid());
        protected override IEnumerable<object> GetEqualityComponents()
        {
           yield return Value;
        }
    }
}
