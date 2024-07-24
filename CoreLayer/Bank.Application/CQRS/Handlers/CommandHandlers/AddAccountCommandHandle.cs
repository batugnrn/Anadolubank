using Bank.Application.CQRS.Commands.RequestCommands;
using Bank.Application.CQRS.Commands.ResponseCommands;
using Bank.Application.Repositories.AccountRepository;
using Bank.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.CQRS.Handlers.CommandHandlers
{
    public class AddAccountCommandHandle : IRequestHandler<AddAccountCommandRequest, AddAccountCommandResponse>
    {
        private readonly IAccountWriteRepository _accountWriteRepository;
        public AddAccountCommandHandle(IAccountWriteRepository accountWriteRepository)
        {
            _accountWriteRepository = accountWriteRepository;
        }

        public async Task<AddAccountCommandResponse> Handle(AddAccountCommandRequest request, CancellationToken cancellationToken)
        {
            var a = await _accountWriteRepository.AddAsync(new()
            {
                Id = Guid.Parse(request.Id),
                Balance = 0
            });
            await _accountWriteRepository.SaveAsync();
            return new();
        }
    }
}
