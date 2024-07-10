using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Entities
{
    public class Login
    {
        public int LoginId { get; set; }
        [Required]
        public string Password { get; set; }
        public Customers Customers { get; set; }
    }
}
