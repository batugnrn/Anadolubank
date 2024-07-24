using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.DTOs
{
    public class AccountDTOs
    {
        public Guid Id { get; set; }
        public int AccountNumber { get; set; }
        public float Balance { get; set; }
    }
}
