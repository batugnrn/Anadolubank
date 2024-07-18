using Bank.Application.Repositories.AccountRepository;
using Bank.Domain.Entities;
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
        private readonly IAccountReadRepository _accountReadRepository;
        private readonly IAccountWriteRepository _accountWriteRepository;
        public EFTController(IAccountReadRepository accountReadRepository, IAccountWriteRepository accountWriteRepository)
        {
            _accountReadRepository = accountReadRepository;
            _accountWriteRepository = accountWriteRepository;
        }
        [HttpPost]
        public async Task<IActionResult> SentEft(string myId, int senderAccountNumber, float amount)
        {
            
            var claim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Account sender = await _accountReadRepository.GetByIdAsync(myId);
            Account receiver = await _accountReadRepository.GetSingleAsync(x=>x.AccountNumber == senderAccountNumber);
            if (receiver != null)
            {
                if (sender.Balance > amount)
                {
                    sender.Balance = sender.Balance - amount;
                    _accountWriteRepository.UpdateAsync(sender);
                    receiver.Balance = receiver.Balance + amount;
                    await _accountWriteRepository.SaveAsync();
                    return Ok(sender);
                }
                else
                {
                    return BadRequest("Yetersiz bakiye!..");
                }
            }
            else 
            {
                return BadRequest("Yanlış IBAN numarası!..");
            }


        }
    }
}
