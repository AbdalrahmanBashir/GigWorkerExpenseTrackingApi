using GigWorkerExpenseTracking.Domain.UserAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigWorkerExpenseTracking.Application.DTOs.AuthenticationDTOs
{
    public class AuthResult
    {
        public bool Success { get; set; }
        public UserId? userId { get; set; }
        public string? UserName { get; set; }
        public string Token { get; internal set; }
    }
}
