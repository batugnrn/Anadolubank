using Bank.Application.Repositories.AccountRepository;
using Bank.Domain.Entities;
using Bank.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Persistance.RepositoryConcreates.AccountConcreates
{
    public class AccountReadRepository : ReadRepository<Account>, IAccountReadRepository
    {
        public AccountReadRepository(BankApiDbContext context) : base(context)
        {
        }
    }
}
