using Bank.Application.Repositories.CustomerRepository;
using Bank.Domain.Entities;
using Bank.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Persistance.RepositoryConcreates.CustomerConcreates
{
    public class CustomerWriteRepository : WriteRepository<Customers>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(BankApiDbContext context) : base(context)
        {
        }
    }
}
