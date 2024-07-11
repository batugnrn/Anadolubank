using Bank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Repositories.AccountRepository
{
    public interface IAccountReadRepository : IReadRepository<Account>
    {
    }
}
