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
    public class AccountWriteRepository : WriteRepository<Account>, IAccountWriteRepository
    {
        public AccountWriteRepository(BankApiDbContext context) : base(context)
        {
        }
    }
}
