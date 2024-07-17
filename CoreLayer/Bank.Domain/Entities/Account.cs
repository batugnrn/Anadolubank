using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Entities
{
    public class Account:Base
    {
        [Key]
        public int AccountNumber { get; set; }
        public float Balance { get; set; }
    }
}
