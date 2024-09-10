using GigWorkerExpenseTracking.Application.DTOs.ExpensesDTOs;
using GigWorkerExpenseTracking.Application.DTOs.PagingsDTOs;
using GigWorkerExpenseTracking.Application.Features.Expenses.AddExpense;
using GigWorkerExpenseTracking.Application.Features.Expenses.ExpensesByUser;
using GigWorkerExpenseTracking.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace GigWorkerExpenseTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        public readonly ISender _sender;

        public ExpenseController(ISender sender)
        {
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateExpense([FromBody] AddExpenseDto addExpenseDto)
        {
            var exp = await _sender.Send(new AddExpenseCommand { AddExpenseDto = addExpenseDto });
            if (exp == null!)
            {
                return BadRequest("Failed to create expense.");
            }

            return Ok(exp);
        }




        [HttpGet("{userId}")]
        
        public async Task<ActionResult<PagedResponse<ExpenseDto>>> GetExpenses(Guid userId, [FromQuery] PagingDTO pagingdDTO)
        {
            var expenses = await _sender.Send(new ExpensesByUserQuery { UserId = userId, paging = pagingdDTO });
            if (expenses == null!)
            {
                return BadRequest("Failed to create expense.");
            }

            return Ok(expenses);
        }


    }
}
