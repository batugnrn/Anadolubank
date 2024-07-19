using Bank.Application.Repositories.LoginRepository;
using Bank.Application.Repositories.TransactionRepository;
using Bank.Domain.Entities;
using Bank.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Persistance.RepositoryConcreates.TransactionConcreates
{
    public class TransactionReadRepository : ReadRepository<Transaction>, ITransactionReadRepository
    {
        public TransactionReadRepository(BankApiDbContext context) : base(context)
        {
        }
    }
}
