using Bank.Application.Abstractions;
using Bank.Application.CQRS.Commands.RequestCommands;
using Bank.Application.CQRS.Commands.ResponseCommands;
using Bank.Application.DTOs;
using Bank.Application.Repositories.CustomerRepository;
using Bank.Domain.Entities;
using Bank.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Bank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginCommandRequest loginCommandRequest)
        {
            LoginCommandResponse response = await _mediator.Send(loginCommandRequest);
            return Ok(response);   
        }
    }
}
