using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.ViewModels.Transaction
{
    public class TransactionTypeEnum
    {
        public enum TransactionType
        {
            Gelen_EFT,
            Giden_EFT,
            Fatura,
            ATM_Para_Cekme,
            ATM_Para_Yatırma,
            Yatırım,
            Pos
        }
    }
}
