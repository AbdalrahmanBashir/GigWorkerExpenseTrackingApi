using GigWorkerExpenseTracking.Domain.MileageAggregate;

namespace GigWorkerExpenseTracking.Application.Services
{
    public class MileageReportService
    {

        private readonly List<Mileage> _mileageEntries;

        public MileageReportService(List<Mileage> mileageEntries)
        {
            _mileageEntries = mileageEntries ?? throw new ArgumentNullException(nameof(mileageEntries));
        }

        public decimal GetTotalMileageForMonth(DateTime month)
        {
            var firstDayOfMonth = new DateTime(month.Year, month.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            var mileageWithinMonth = _mileageEntries.Where(m => m.LogDate >= firstDayOfMonth && m.LogDate <= lastDayOfMonth);
            return mileageWithinMonth.Sum(m => m.Distance);
        }

        public decimal GetTotalMileageForWeek(DateTime weekStart)
        {
            var endOfWeek = weekStart.AddDays(6);

            var mileageWithinWeek = _mileageEntries.Where(m => m.LogDate >= weekStart && m.LogDate <= endOfWeek);
            return mileageWithinWeek.Sum(m => m.Distance);
        }
    }
}
