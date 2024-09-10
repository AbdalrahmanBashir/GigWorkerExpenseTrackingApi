using GigWorkerExpenseTracking.Application.DTOs.MileagesDTOs;
using GigWorkerExpenseTracking.Application.Features.Mileages.AddMileage;
using GigWorkerExpenseTracking.Application.Features.Mileages.GetMileageById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GigWorkerExpenseTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MileageController : ControllerBase
    {
        private readonly ISender _sender;

        public MileageController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateMileage([FromBody] AddMileageDto addMileageDto)
        {
            var exp = await _sender.Send(new AddMileageCommand { AddMileageDto = addMileageDto });
            return Ok(exp);
        }

        [HttpGet("{MileageId}")]
        public async Task<ActionResult<MileageDto>> GetMileage(Guid MileageId)
        {
            var expenses = await _sender.Send(new GetMileageByIdQuery { MileageId = MileageId });
            return Ok(expenses);
        }
    }
}
