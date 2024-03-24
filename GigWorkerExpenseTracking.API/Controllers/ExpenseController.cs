using GigWorkerExpenseTracking.Application.DTOs.ExpenseItemDTOs;
using GigWorkerExpenseTracking.Application.DTOs.ExpensesDTOs;
using GigWorkerExpenseTracking.Application.Features.Expenses.AddExpense;
using GigWorkerExpenseTracking.Application.Features.Expenses.AddExpenseItem;
using GigWorkerExpenseTracking.Application.Features.Expenses.ExpenseById;
using GigWorkerExpenseTracking.Application.Features.Expenses.ExpensesByUser;
using GigWorkerExpenseTracking.Domain.ExpenseAggregate;
using GigWorkerExpenseTracking.Domain.ExpenseAggregate.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("CreateExpenseItem")]
        public async Task<ActionResult<Guid>> CreateExpenseItem([FromBody] AddExpenseItemDto addExpenseItem)
        {
            var exp = await _sender.Send(new AddExpenseItemCommand { AddExpenseItemDto = addExpenseItem});
            if (exp == null!)
            {
                return BadRequest("Failed to create expense.");
            }

            return Ok(exp);
        }


        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<ExpenseDto>>> GetExpenses(Guid userId)
        {
            var expenses = await _sender.Send(new ExpensesByUserQuery { UserId = userId });
            if (expenses == null!)
            {
                return BadRequest("Failed to create expense.");
            }

            return Ok(expenses);
        }

        [HttpGet]
        [Route("expenses/{expenseId}")]
        public async Task<ActionResult<(Expense, IEnumerable<ExpenseItem>)>> GetExpenseById(Guid expenseId)
        {
            var expenses = await _sender.Send(new ExpenseByIdQuery { ExpenseId = expenseId });
            if (expenses == null!)
            {
                return BadRequest("Failed to create expense.");
            }

            return Ok(expenses);
        }
    }
}
