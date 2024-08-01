using Bank.Application.CQRS.Commands.RequestCommands;
using Bank.Application.CQRS.Commands.ResponseCommands;
using Bank.Application.Repositories.AccountRepository;
using Bank.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.CQRS.Handlers.CommandHandlers
{
    public class RemoveAccountCommandHandle : IRequestHandler<RemoveAccountCommandRequest, RemoveAccountCommandResponse>
    {
        private readonly IAccountWriteRepository _accountWriteRepository;
        private readonly IAccountReadRepository _accountReadRepository;
        public RemoveAccountCommandHandle(IAccountWriteRepository accountWriteRepository,IAccountReadRepository accountReadRepository)
        {
            _accountWriteRepository = accountWriteRepository;
            _accountReadRepository = accountReadRepository;
        }

        public async Task<RemoveAccountCommandResponse> Handle(RemoveAccountCommandRequest request, CancellationToken cancellationToken)
        {
            Account account = _accountReadRepository.GetWhere(x => x.AccountNumber == request.AccountNumber).FirstOrDefault();
            _accountWriteRepository.Remove(account);
            _accountWriteRepository.SaveAsync();
            return new();

        }
    }
}
