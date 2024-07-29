using Bank.Application.CQRS.Queries.RequestQueries;
using Bank.Application.CQRS.Queries.ResponseQueries;
using Bank.Application.DTOs;
using Bank.Application.Repositories.AccountRepository;
using Bank.Application.Repositories.CustomerRepository;
using Bank.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.CQRS.Handlers.QueryHandlers
{
    public class GetBalanceByIdQueryHandle : IRequestHandler<GetBalanceByIdQueryRequest, GetBalanceByIdQueryResponse>
    {
        private readonly IAccountReadRepository _accountReadRepository;
        public GetBalanceByIdQueryHandle(IAccountReadRepository accountReadRepository)
        {
            _accountReadRepository = accountReadRepository;
        }
        public async Task<GetBalanceByIdQueryResponse> Handle(GetBalanceByIdQueryRequest request, CancellationToken cancellationToken)
        {
            List<Account> accounts = await _accountReadRepository.GetWhere(x=>x.Id == Guid.Parse(request.Id)).ToListAsync();
            List<AccountDTOs> responseList = accounts.Select(item => new AccountDTOs
            {
                Id = item.Id,
                Balance = item.Balance,
                AccountNumber = item.AccountNumber,
            }).ToList();
            return new GetBalanceByIdQueryResponse
            {
                Accounts = responseList
            }; 
        }
    }
}
