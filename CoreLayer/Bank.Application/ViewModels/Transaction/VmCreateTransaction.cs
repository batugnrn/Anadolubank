using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.ViewModels.Transaction
{
    public class VmCreateTransaction
    {
        public string TransactionId { get; set; }
        public string TransactionType { get; set; }
        public DateTime DateTime { get; set; }
        public float Amount { get; set; }
        public float newBalance { get; set; }
        public string? description { get; set; }

    }
}
