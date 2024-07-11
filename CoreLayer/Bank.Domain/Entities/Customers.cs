using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.Domain.Entities
{
    public class Customers:Base
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Gender { get; set; }
        [MaxLength(11)]
        [Required]
        public long Tcno { get; set; }
        [Required]
        public string Birthday { get; set; }
        public DateTime CreatedDate { get; set;} = DateTime.Now;
        [Required]
        [DataType(DataType.PhoneNumber)]
        public long PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set;}
        [Required]
        public string Adress { get; set;}
        ///public ICollection<Account> Accounts { get; set; }
        [Required]
        public string Password { get; set; }
        ///

    }
}
