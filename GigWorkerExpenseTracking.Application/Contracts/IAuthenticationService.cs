using GigWorkerExpenseTracking.Domain.UserAggregate;
using GigWorkerExpenseTracking.Domain.UserAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigWorkerExpenseTracking.Application.Contracts
{
    public interface IAuthenticationService
    {
        string GenerateToken(User user);
        bool ValidateToken(string token);
    }
}
