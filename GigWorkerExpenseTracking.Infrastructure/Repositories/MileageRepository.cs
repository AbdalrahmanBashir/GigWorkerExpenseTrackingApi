using GigWorkerExpenseTracking.Application.Contracts;
using GigWorkerExpenseTracking.Domain.MileageAggregate;
using GigWorkerExpenseTracking.Domain.MileageAggregate.ValueObjects;
using GigWorkerExpenseTracking.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace GigWorkerExpenseTracking.Infrastructure.Repositories
{
    public class MileageRepository : IMileageRepository
    {
        private readonly ApplicationDbContext _context;

        public MileageRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddAsync(Mileage mileage)
        {
            _context.Mileages.Add(mileage);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(MileageId mileageId)
        {
            var result = _context.Mileages.Where(m => m.Id! == mileageId).FirstOrDefault();
            if (result! != null!)
            {
                _context.Mileages.Remove(result);
            }

            await   _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Mileage>> GetAllByUserIdAsync(UserId userId)
        {
            var result = await _context.Mileages
                .AsNoTracking()
                .Where(m => m.UserId! == userId)
                .ToListAsync();
            return result;
        }

        public async Task<Mileage> GetByIdAsync(MileageId mileageId)
        {
            var result = await _context.Mileages
                .Where(m => m.Id! == mileageId)
                .FirstOrDefaultAsync();

            return result!;
        }

        public async Task<IEnumerable<Mileage>> GetTotalMileageForMonth(DateTime firstDayOfMonth, DateTime lastDayOfMonth)
        {
            var result = await _context.Mileages
                .AsNoTracking()
                .Where(m => m.LogDate >= firstDayOfMonth && m.LogDate <= lastDayOfMonth)
                .ToListAsync();

            return result;
        }

        public async Task<IEnumerable<Mileage>> GetTotalMileageForWeek(DateTime weekStart, DateTime weekEnd)
        {
            var result = await  _context.Mileages
                .AsNoTracking()
                .Where(m => m.LogDate >= weekStart && m.LogDate <= weekEnd)
                .ToListAsync();

            return result;
        }

        public Task<IEnumerable<Mileage>> GetTotalMileageForYear(DateTime year)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Mileage mileage)
        {
            throw new NotImplementedException();
        }
    }
}
