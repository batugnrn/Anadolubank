using Bank.Application.Repositories.TransactionRepository;
using Bank.Application.ViewModels.Transaction;
using Bank.Domain.Entities;
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
        private readonly ITransactionReadRepository _transactionReadRepository;
        public TransactionController(ITransactionReadRepository transactionReadRepository)
        {
            _transactionReadRepository = transactionReadRepository;
        }

        [HttpGet("{accountNumber}")]
        public async Task<IActionResult> GetAccountTransaction(string accountNumber)
        {
            List<VmCreateTransaction> vmCreateTransactions = new List<VmCreateTransaction>();

            IQueryable<Transaction> receive = _transactionReadRepository.GetWhere(x => x.receiverAccountNumber == accountNumber);
            List<Transaction> receiveTransactions = await receive.ToListAsync();   
            receiveTransactions.ForEach(x =>
            {
                VmCreateTransaction transaction = new VmCreateTransaction();
                transaction.TransactionId = x.Id.ToString();
                transaction.TransactionType = TransactionTypeEnum.TransactionType.Gelen_EFT.ToString();
                transaction.DateTime = x.DateTime;
                transaction.Amount = x.Amount;
                transaction.newBalance = x.receiverNewBalance;
                transaction.description = x.description;
                vmCreateTransactions.Add(transaction);
            }); 
            IQueryable<Transaction> sender = _transactionReadRepository.GetWhere(x => x.senderAccountNumber == accountNumber);
            List<Transaction> senderTransactions = await sender.ToListAsync();   
            senderTransactions.ForEach(x =>
            {
                VmCreateTransaction transaction = new VmCreateTransaction();
                transaction.TransactionId = x.Id.ToString();
                transaction.TransactionType = TransactionTypeEnum.TransactionType.Giden_EFT.ToString();
                transaction.DateTime = x.DateTime;
                transaction.Amount = x.Amount;
                transaction.newBalance = x.senderNewBalance;
                transaction.description = x.description;
                vmCreateTransactions.Add(transaction);
            });
            

            return Ok(vmCreateTransactions.OrderByDescending(p=>p.DateTime).ToList());
        }
    }
}
