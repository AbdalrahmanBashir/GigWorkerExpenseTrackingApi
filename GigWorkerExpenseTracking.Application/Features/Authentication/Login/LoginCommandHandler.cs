using GigWorkerExpenseTracking.Application.Contracts;
using GigWorkerExpenseTracking.Application.DTOs.AuthenticationDTOs;
using MediatR;
using System.Text;

namespace GigWorkerExpenseTracking.Application.Features.Authentication.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthResult>
    {
        private readonly IAuthRepository? _authRepository;
        private readonly IAuthenticationService? _authenticationService;

        public LoginCommandHandler(IAuthRepository? authRepository, IAuthenticationService? authenticationService)
        {
            _authRepository = authRepository;
            _authenticationService = authenticationService;
        }

        public async Task<AuthResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _authRepository!.GetUserByUsernameAsync(request.LogUser!.Username!);

            if (user == null! || !VerifyPasswordHash(request.LogUser.Password!, user.PasswordHash, user.PasswordSalt))
            {
                return new AuthResult { Success = false};
            }

            var token = _authenticationService!.GenerateToken(user);

            return new AuthResult { Success = true, Token = token};
        }

        private static bool VerifyPasswordHash(string password, byte[] PasswordHash, byte[] PasswordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512(PasswordSalt);
            var NewpasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int index = 0; index < NewpasswordHash.Length; index++)
                if (NewpasswordHash[index] != PasswordHash[index]) return false;
            return true;
        }
    }
}
