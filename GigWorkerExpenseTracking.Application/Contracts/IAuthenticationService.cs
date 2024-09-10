using GigWorkerExpenseTracking.Domain.UserAggregate;

namespace GigWorkerExpenseTracking.Application.Contracts
{
    public interface IAuthenticationService
    {
        string GenerateToken(User user);
        bool ValidateToken(string token);
    }
}
