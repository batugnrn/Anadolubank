using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Entities
{
    public class Account
    {
        public int AccountId { get; set; }
        public float Balance { get; set; }
        public Customers Customers { get; set; }
    }
}
