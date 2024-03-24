using GigWorkerExpenseTracking.Application.DTOs.AuthenticationDTOs;
using GigWorkerExpenseTracking.Application.Features.Authentication.Login;
using GigWorkerExpenseTracking.Application.Features.Authentication.Registration;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GigWorkerExpenseTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public readonly ISender _sender;

        public AccountController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<AuthResult>> Register([FromBody] AddUserDto AddUserDto)
        {
            var newUser = await _sender.Send(new RegisterUserCommand { AddUser = AddUserDto });

            return Ok(newUser);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<AuthResult>> Login([FromBody] LogUserDto LogUserDto)
        {
            var newUser = await _sender.Send(new LoginCommand { LogUser = LogUserDto });

            return Ok(newUser);
        }

    }
}
