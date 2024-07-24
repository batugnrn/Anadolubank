using Bank.Application.CQRS.Commands.RequestCommands;
using Bank.Application.CQRS.Commands.ResponseCommands;
using Bank.Application.Repositories.AccountRepository;
using Bank.Application.Repositories.TransactionRepository;
using Bank.Domain.Entities;
using Bank.Persistance.RepositoryConcreates.TransactionConcreates;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Bank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Customer")]
    public class EFTController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EFTController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> SendEft(SendEftCommandRequest sendEftCommandRequest)
        {
            SendEftCommandResponse response = await _mediator.Send(sendEftCommandRequest);
            return Ok(response);
        }
    }
}
