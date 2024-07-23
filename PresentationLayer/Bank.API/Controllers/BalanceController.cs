using Bank.Application.Repositories.AccountRepository;
using Bank.Application.Repositories.CustomerRepository;
using Bank.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = "Customer")]

    public class BalanceController : ControllerBase
    {
        private readonly IAccountReadRepository _accountReadRepository;

        public BalanceController(IAccountReadRepository accountReadRepository)
        {
            _accountReadRepository = accountReadRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBalanceById(string id)
        {
            // Account c =  _customerReadRepository.GetWhere(x => x.Account.Id == Guid.Parse(id));
            Account c = await _accountReadRepository.GetByIdAsync(id);
            return Ok(c);
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
