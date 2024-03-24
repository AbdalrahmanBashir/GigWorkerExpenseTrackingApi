using GigWorkerExpenseTracking.Application.Contracts;
using GigWorkerExpenseTracking.Application.DTOs.AuthenticationDTOs;
using GigWorkerExpenseTracking.Domain.UserAggregate;

namespace GigWorkerExpenseTracking.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        
        private readonly ApplicationDbContext _context;

        public AuthRepository(ApplicationDbContext context)
        {

            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            var user =  _context.Users.FirstOrDefault(u => u.Username == username);

            return user!;
        }

        public async Task Register(User addNewUser)
        {
            _context.Users.Add(addNewUser);
            _context.SaveChanges();

        }

        public async Task Login(LogUserDto logUser)
        {
            _context.Users.FirstOrDefault(u => u.Username == logUser.Username);
        }
    }
}
