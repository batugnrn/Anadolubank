using Bank.Application.Repositories.LoginRepository;
using Bank.Domain.Entities;
using Bank.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Persistance.RepositoryConcreates.LoginConcreates
{
    public class LoginReadRepository : ReadRepository<Login>, ILoginReadRepository
    {
        public LoginReadRepository(BankApiDbContext context) : base(context)
        {
        }
    }
}
