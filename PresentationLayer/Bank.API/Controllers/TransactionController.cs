using Bank.Application.CQRS.Queries.RequestQueries;
using Bank.Application.CQRS.Queries.ResponseQueries;
using Bank.Application.Repositories.TransactionRepository;
using Bank.Application.ViewModels.Transaction;
using Bank.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Customer")]
    public class TransactionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{accountNumber}")]
        public async Task<IActionResult> GetAccountTransaction([FromRoute] GetAccountTransactionQueryRequest getAccountTransactionQueryRequest)
        {
            GetAccountTransactionQueryResponse response = await _mediator.Send(getAccountTransactionQueryRequest);
            return Ok(response);
        }






    }
}
