using Bank.Application.Repositories.AccountRepository;
using Bank.Application.Repositories.CustomerRepository;
using Bank.Domain.Entities;
<<<<<<< HEAD
using Microsoft.AspNetCore.Authorization;
=======
>>>>>>> c4824986fd69203b8ed3115c5176ec8b71a6932a
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
<<<<<<< HEAD
    [Authorize(AuthenticationSchemes = "Customer")]
=======
>>>>>>> c4824986fd69203b8ed3115c5176ec8b71a6932a
    public class BalanceController : ControllerBase
    {
        private readonly IAccountReadRepository _accountReadRepository;

        public BalanceController(IAccountReadRepository accountReadRepository)
        {
            _accountReadRepository = accountReadRepository;

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBalance(string id)
        {
            // Account c =  _customerReadRepository.GetWhere(x => x.Account.Id == Guid.Parse(id));
            Account c = await _accountReadRepository.GetByIdAsync(id);
            return Ok(c.Balance);
        }
    }
}
