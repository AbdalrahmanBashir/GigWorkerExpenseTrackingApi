using GigWorkerExpenseTracking.Domain.Commons;
using GigWorkerExpenseTracking.Domain.MileageAggregate.ValueObjects;
using GigWorkerExpenseTracking.Domain.UserAggregate.ValueObjects;
using System;

namespace GigWorkerExpenseTracking.Domain.MileageAggregate
{
    public class Mileage : AggregateRoot<MileageId>
    {
        public UserId? UserId { get; private set; }
        public DateTime LogDate { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime LastModifiedDate { get; private set; }

        public decimal Distance { get; private set; }

        private Mileage(MileageId id, UserId userId, DateTime logDate, decimal distance, DateTime createdDate, DateTime lastModifiedDate) : base(id)
        {
            UserId = userId ?? throw new ArgumentNullException(nameof(userId));
            LogDate = logDate;
            Distance = distance;
            CreatedDate = createdDate;
            LastModifiedDate = lastModifiedDate;
        }

        private Mileage() : base(default!)
        {

        }

        public  Mileage CreateMileage(UserId userId, DateTime logDate, decimal distance)
        {
            if (distance <= 0)
                throw new ArgumentOutOfRangeException(nameof(distance), "Distance must be greater than zero.");

            var id = MileageId.CreateId();
            CreatedDate = DateTime.UtcNow;
            LastModifiedDate = CreatedDate;
            return new Mileage(id, userId, logDate, distance, CreatedDate, LastModifiedDate);
        }

        public void UpdateMileage(DateTime logDate, decimal distance)
        {
            if (distance <= 0)
                throw new ArgumentOutOfRangeException(nameof(distance), "Distance must be greater than zero.");

            LogDate = logDate;
            Distance = distance;
            LastModifiedDate = DateTime.UtcNow;
        }

        public void DeleteMileage()
        {
            UserId = null;
            LogDate = default;
            Distance = default;
            LastModifiedDate = DateTime.UtcNow;
        }

        public decimal CalculateMileageCost(decimal ratePerMile)
        {
            return Distance * ratePerMile;
        }


        public decimal CalculateTaxDeduction(decimal standardRatePerMile)
        {
            // Assuming standardRatePerMile is provided by tax regulations
            return Distance * standardRatePerMile;
        }

        public decimal CalculateTaxReimbursement(decimal taxRate)
        {
            // Assuming taxRate is provided by tax regulations
            return CalculateMileageCost(0.50m) * taxRate;
        }
    }
}
