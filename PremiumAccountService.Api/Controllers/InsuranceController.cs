using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PremiumAccountService.Application.Commands;
using PremiumAccountService.Application.Query;

namespace PremiumAccountService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly IMediator _mediator;
        public InsuranceController(IMediator mediator)
        {
                _mediator = mediator;
        }
        [HttpPost("requests")]
        public async Task<IActionResult> CreateRequest([FromBody] CreateInsuranceRequestCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("requests")]
        public async Task<IActionResult> GetRequests()
        {
            var result = await _mediator.Send(new GetInsuranceRequestsQuery());
            return Ok(result);
        }
    }
}
