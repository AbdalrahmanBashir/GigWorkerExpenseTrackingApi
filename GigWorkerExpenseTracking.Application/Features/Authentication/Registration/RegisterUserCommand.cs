using GigWorkerExpenseTracking.Application.DTOs.AuthenticationDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigWorkerExpenseTracking.Application.Features.Authentication.Registration
{
    public class RegisterUserCommand : IRequest<AuthResult>
    {
        public AddUserDto? AddUser { get; set; }
    }
}
