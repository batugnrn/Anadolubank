using Bank.Application.Repositories.AccountRepository;
using Bank.Application.Repositories.TransactionRepository;
using Bank.Domain.Entities;
using Bank.Persistance.RepositoryConcreates.TransactionConcreates;
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
        private readonly ITransactionWriteRepository _transactionWriteRepository;
        public EFTController(IAccountReadRepository accountReadRepository, IAccountWriteRepository accountWriteRepository, ITransactionWriteRepository transactionWriteRepository)
        {
            _accountReadRepository = accountReadRepository;
            _accountWriteRepository = accountWriteRepository;
            _transactionWriteRepository = transactionWriteRepository;
        }
        [HttpPost]
        public async Task<IActionResult> SentEft(string myId, int senderAccountNumber, float amount, string? message)
        {
            
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

                    await _transactionWriteRepository.AddAsync(new()
                    {
                        Id = Guid.NewGuid(),
                        DateTime = DateTime.Now,
                        senderAccountNumber = sender.AccountNumber.ToString(),
                        receiverAccountNumber = receiver.AccountNumber.ToString(),
                        Amount = amount,
                        senderNewBalance = sender.Balance,
                        receiverNewBalance = receiver.Balance,
                        description = message,
                    });
                    await _transactionWriteRepository.SaveAsync();
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
