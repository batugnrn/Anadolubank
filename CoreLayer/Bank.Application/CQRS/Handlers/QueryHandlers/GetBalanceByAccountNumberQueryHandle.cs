using Bank.Application.CQRS.Queries.RequestQueries;
using Bank.Application.CQRS.Queries.ResponseQueries;
using Bank.Application.Repositories.AccountRepository;
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
    public class GetBalanceByAccountNumberQueryHandle : IRequestHandler<GetBalanceByAccountNumberQueryRequest, GetBalanceByAccountNumberQueryResponse>
    {
        private readonly IAccountReadRepository _accountReadRepository;
        public GetBalanceByAccountNumberQueryHandle(IAccountReadRepository accountReadRepository)
        {
            _accountReadRepository = accountReadRepository;
        }
        public async Task<GetBalanceByAccountNumberQueryResponse> Handle(GetBalanceByAccountNumberQueryRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Account> c = _accountReadRepository.GetWhere(x => x.AccountNumber == request.accountNumber);
            return new GetBalanceByAccountNumberQueryResponse
            {
                Account = c
            };
        }  
    }
}
