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
        public static MileageId CreateId()
        {
            return new MileageId(Guid.NewGuid());
        }

        public static MileageId ConvertId(Guid value)
        {
            return new MileageId(value);
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
           yield return Value;
        }
    }
}
