using Bank.Application.ViewModels.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.CQRS.Queries.ResponseQueries
{
    public class GetAccountTransactionQueryResponse
    {
        public List<VmCreateTransaction> vmCreateTransactions {  get; set; } 

    }
}
