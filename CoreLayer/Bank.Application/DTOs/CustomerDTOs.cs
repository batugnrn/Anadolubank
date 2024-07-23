using Bank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.DTOs
{
    public class CustomerDTOs
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public long Tcno { get; set; }
        public string Birthday { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string Password { get; set; }
       
        public Account Account { get; set; }
    }
}
