using AutoMapper;
using GigWorkerExpenseTracking.Application.Contracts;
using GigWorkerExpenseTracking.Application.DTOs.AuthenticationDTOs;
using GigWorkerExpenseTracking.Domain.UserAggregate;
using MediatR;
using System.Text;

namespace GigWorkerExpenseTracking.Application.Features.Authentication.Registration
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, AuthResult>
    {
        public readonly IMapper _mapper;
        private readonly IAuthRepository? _authRepository;
        public byte[]? PasswordHash { get; private set; }
        public byte[]? PasswordSalt { get; private set; }

        public RegisterUserCommandHandler(IMapper mapper, IAuthRepository? authRepository)
        {
            _mapper = mapper;
            _authRepository = authRepository;
        }

        public async Task<AuthResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var currentuser = _mapper.Map<User>(request.AddUser);
            CreatePasswordHash(request.AddUser!.Password, out byte[] passwordHash, out byte[] passwordSalt);
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            var newuser = User.CreateNewUser(
              currentuser.FirstName, 
              currentuser.LastName, 
              currentuser.Username,
              currentuser.Email,
              passwordHash,
              passwordSalt
              );
            await _authRepository!.Register(newuser);


            var authResult = new AuthResult { Success = true, UserName = newuser.Username, userId= newuser.Id };
            return authResult;
        }

        private void CreatePasswordHash(string? password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password!));
            passwordSalt = hmac.Key;
        }
    }
}
