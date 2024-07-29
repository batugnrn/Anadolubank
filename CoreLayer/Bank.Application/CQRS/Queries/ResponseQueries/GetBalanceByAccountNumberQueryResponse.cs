using Bank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.CQRS.Queries.ResponseQueries
{
    public class GetBalanceByAccountNumberQueryResponse
    {
        public IQueryable<Account> Account { get; set; }
    }
}
