using Bank.Application.Abstractions;
using Bank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Persistance.Concreates
{
    public class CustomerService : ICustomerService
    {
        public List<Customers> GetCustomers()
        => new()
        {
           new Customers { Name = "Name1", Surname = "Surname1", Gender = "Male", Tcno = 11111111111, Birthday = DateTime.Now.ToString(), CreatedDate = DateTime.Now,   },
           new Customers { Name = "Name2", Surname = "Surname2", Gender = "Female", Tcno = 22222222222, Birthday = DateTime.Now.ToString(), CreatedDate = DateTime.Now, },
        };
    }
}
