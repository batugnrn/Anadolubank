﻿using Bank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Repositories.TransactionRepository
{
    public interface ITransactionWriteRepository: IWriteRepository<Transaction>
    {

    }
}
