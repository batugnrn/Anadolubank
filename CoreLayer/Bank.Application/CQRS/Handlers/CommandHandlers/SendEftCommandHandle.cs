using Bank.Application.CQRS.Commands.RequestCommands;
using Bank.Application.CQRS.Commands.ResponseCommands;
using Bank.Application.Repositories.AccountRepository;
using Bank.Application.Repositories.TransactionRepository;
using Bank.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.CQRS.Handlers.CommandHandlers
{
    public class SendEftCommandHandle : IRequestHandler<SendEftCommandRequest, SendEftCommandResponse>
    {
        private readonly IAccountReadRepository _accountReadRepository;
        private readonly IAccountWriteRepository _accountWriteRepository;
        private readonly ITransactionWriteRepository _transactionWriteRepository;
        public SendEftCommandHandle(IAccountReadRepository accountReadRepository, IAccountWriteRepository accountWriteRepository, ITransactionWriteRepository transactionWriteRepository)
        {
            _accountReadRepository = accountReadRepository;
            _accountWriteRepository = accountWriteRepository;
            _transactionWriteRepository = transactionWriteRepository;
        }
        public async Task<SendEftCommandResponse> Handle(SendEftCommandRequest request, CancellationToken cancellationToken)
        {
            Account sender = await _accountReadRepository.GetSingleAsync(x => x.AccountNumber == request.senderAccountNumber);
            Account receiver = await _accountReadRepository.GetSingleAsync(x => x.AccountNumber == request.receiverAccountNumber);
            if (receiver != null)
            {
                if (sender.Balance > request.amount)
                {
                    sender.Balance = sender.Balance - request.amount;
                    _accountWriteRepository.UpdateAsync(sender);
                    receiver.Balance = receiver.Balance + request.amount;
                    await _accountWriteRepository.SaveAsync();

                    await _transactionWriteRepository.AddAsync(new()
                    {
                        Id = Guid.NewGuid(),
                        DateTime = DateTime.Now,
                        senderAccountNumber = sender.AccountNumber.ToString(),
                        receiverAccountNumber = receiver.AccountNumber.ToString(),
                        Amount = request.amount,
                        senderNewBalance = sender.Balance,
                        receiverNewBalance = receiver.Balance,
                        description = request.message,
                    });
                    await _transactionWriteRepository.SaveAsync();
                    return new SendEftCommandResponse
                    {
                        Account = sender,
                    };
                }
                else
                {
                    throw new Exception("Yetersiz bakiye!..");
                }
            }
            else
            {
                throw new Exception("Yanlış IBAN numarası!..");
            }
        }
    }
}
