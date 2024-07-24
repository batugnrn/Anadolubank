using Bank.Application.CQRS.Commands.RequestCommands;
using Bank.Application.CQRS.Commands.ResponseCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Customer")]

    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("{Id}")]
        public async Task<IActionResult> AddAccount([FromRoute]AddAccountCommandRequest addAccountCommandRequest)
        {
            AddAccountCommandResponse response = await _mediator.Send(addAccountCommandRequest);
            return Ok(response);
        }
    }
}
