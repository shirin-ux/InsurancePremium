using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PremiumAccountService.Application.Commands;

namespace PremiumAccountService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PremiumController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PremiumController(IMediator mediator)
        {
                _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CalculatePremium([FromBody] CalculatePremiumCommand premiumCommand)
        {

           await _mediator.Send(premiumCommand);
            return Ok();
        }
    }
}
