using GigWorkerExpenseTracking.Application.DTOs.AuthenticationDTOs;
using MediatR;

namespace GigWorkerExpenseTracking.Application.Features.Authentication.Login
{
    public class LoginCommand : IRequest<AuthResult>
    {
        public LogUserDto? LogUser { get; set; }
    }
}
