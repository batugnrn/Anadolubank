using Bank.Application.CQRS.Queries.RequestQueries;
using Bank.Application.CQRS.Queries.ResponseQueries;
using Bank.Application.Repositories.AccountRepository;
using Bank.Application.Repositories.CustomerRepository;
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

    public class BalanceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BalanceController(IMediator mediator)
        {
            _mediator = mediator;   
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetBalanceById([FromRoute]GetBalanceByIdQueryRequest getBalanceByIdQueryRequest)
        {
            GetBalanceByIdQueryResponse response = await _mediator.Send(getBalanceByIdQueryRequest);
            return Ok(response);
        }


        //[HttpGet("{accountNumber}")]
        //public async Task<IActionResult> GetBalanceByAccountNumber(int accountNumber)
        //{
        //    Account c = await _accountReadRepository.GetWhere(x => x.AccountNumber == accountNumber).FirstOrDefaultAsync();
        //    //Account c = await _accountReadRepository.GetByIdAsync(accountNumber);
        //    return Ok(c);
        //}
    }
}
