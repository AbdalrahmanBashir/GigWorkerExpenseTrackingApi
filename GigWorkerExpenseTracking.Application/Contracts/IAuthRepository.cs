using GigWorkerExpenseTracking.Application.DTOs.AuthenticationDTOs;
using GigWorkerExpenseTracking.Domain.UserAggregate;
using MediatR;

namespace GigWorkerExpenseTracking.Application.Contracts
{
    public interface IAuthRepository
    {
        Task Register(User addNewUser);
        Task Login(LogUserDto logUser);

        Task<User> GetUserByUsernameAsync(string Username);
    }
}
