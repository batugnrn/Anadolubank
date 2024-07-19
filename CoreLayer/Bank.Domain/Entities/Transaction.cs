using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Entities
{
    public class Transaction : Base
    {      
        public DateTime DateTime { get; set; }
        public string senderAccountNumber { get; set; }
        public string receiverAccountNumber { get; set; }
        public float Amount { get; set; }
        public float senderNewBalance { get; set;}
        public float receiverNewBalance { get; set;}
        public string? description { get; set; }

    }
}
