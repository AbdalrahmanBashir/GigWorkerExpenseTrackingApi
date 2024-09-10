using GigWorkerExpenseTracking.Domain.MileageAggregate;
using GigWorkerExpenseTracking.Domain.MileageAggregate.ValueObjects;
using GigWorkerExpenseTracking.Domain.UserAggregate.ValueObjects;

namespace GigWorkerExpenseTracking.Application.Contracts
{
    public interface IMileageRepository
    {
        Task<Mileage> GetByIdAsync(MileageId mileageId);
        Task<IEnumerable<Mileage>> GetAllByUserIdAsync(UserId userId);
        Task AddAsync(Mileage mileage);
        Task UpdateAsync(Mileage mileage);
        Task DeleteAsync(MileageId mileageId);
        Task<IEnumerable<Mileage>> GetTotalMileageForYear(DateTime year);
        Task<IEnumerable<Mileage>> GetTotalMileageForMonth(DateTime firstDayOfMonth, DateTime lastDayOfMonth);
        Task<IEnumerable<Mileage>> GetTotalMileageForWeek(DateTime weekStart, DateTime weekEnd);
    }
}
