using Bank.Application.CQRS.Queries.RequestQueries;
using Bank.Application.CQRS.Queries.ResponseQueries;
using Bank.Application.Repositories.TransactionRepository;
using Bank.Application.ViewModels.Transaction;
using Bank.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.CQRS.Handlers.QueryHandlers
{
    public class GetAccountTransactionQueryHandle : IRequestHandler<GetAccountTransactionQueryRequest, GetAccountTransactionQueryResponse>
    {
        private readonly ITransactionReadRepository _transactionReadRepository;
        public GetAccountTransactionQueryHandle(ITransactionReadRepository transactionReadRepository)
        {
            _transactionReadRepository = transactionReadRepository;
        }
        public async Task<GetAccountTransactionQueryResponse> Handle(GetAccountTransactionQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                List<VmCreateTransaction> vmCreateTransactions = new List<VmCreateTransaction>();

                IQueryable<Transaction> receive = _transactionReadRepository.GetWhere(x => x.receiverAccountNumber == request.accountNumber);
                List<Transaction> receiveTransactions = await receive.ToListAsync();
                receiveTransactions.ForEach(x =>
                {
                    VmCreateTransaction transaction = new VmCreateTransaction();
                    transaction.TransactionId = x.Id.ToString();
                    transaction.TransactionType = TransactionTypeEnum.TransactionType.Gelen_EFT.ToString();
                    transaction.DateTime = x.DateTime;
                    transaction.Amount = x.Amount;
                    transaction.newBalance = x.receiverNewBalance;
                    transaction.description = x.description;
                    vmCreateTransactions.Add(transaction);
                });
                IQueryable<Transaction> sender = _transactionReadRepository.GetWhere(x => x.senderAccountNumber == request.accountNumber);
                List<Transaction> senderTransactions = await sender.ToListAsync();
                senderTransactions.ForEach(x =>
                {
                    VmCreateTransaction transaction = new VmCreateTransaction();
                    transaction.TransactionId = x.Id.ToString();
                    transaction.TransactionType = TransactionTypeEnum.TransactionType.Giden_EFT.ToString();
                    transaction.DateTime = x.DateTime;
                    transaction.Amount = x.Amount;
                    transaction.newBalance = x.senderNewBalance;
                    transaction.description = x.description;
                    vmCreateTransactions.Add(transaction);
                });
                if (vmCreateTransactions.Count() != 0)
                {
                    return new GetAccountTransactionQueryResponse
                    {
                        vmCreateTransactions = vmCreateTransactions,
                    };
                }
                else
                {
                    throw new Exception("Hesap Bulunamadı!..");
                    //throw new Exception(HttpStatusCode.NotFound.ToString());
                }
            }
            catch (Exception)
            {

                throw;
            }
            







            //List<VmCreateTransaction> vmCreateTransactions = new List<VmCreateTransaction>();

            //IQueryable<Transaction> receive = _transactionReadRepository.GetWhere(x => x.receiverAccountNumber == request.accountNumber);
            //List<Transaction> receiveTransactions = await receive.ToListAsync();
            //receiveTransactions.ForEach(x =>
            //{
            //    VmCreateTransaction transaction = new VmCreateTransaction();
            //    transaction.TransactionId = x.Id.ToString();
            //    transaction.TransactionType = TransactionTypeEnum.TransactionType.Gelen_EFT.ToString();
            //    transaction.DateTime = x.DateTime;
            //    transaction.Amount = x.Amount;
            //    transaction.newBalance = x.receiverNewBalance;
            //    transaction.description = x.description;
            //    vmCreateTransactions.Add(transaction);
            //});
            //IQueryable<Transaction> sender = _transactionReadRepository.GetWhere(x => x.senderAccountNumber == request.accountNumber);
            //List<Transaction> senderTransactions = await sender.ToListAsync();
            //senderTransactions.ForEach(x =>
            //{
            //    VmCreateTransaction transaction = new VmCreateTransaction();
            //    transaction.TransactionId = x.Id.ToString();
            //    transaction.TransactionType = TransactionTypeEnum.TransactionType.Giden_EFT.ToString();
            //    transaction.DateTime = x.DateTime;
            //    transaction.Amount = x.Amount;
            //    transaction.newBalance = x.senderNewBalance;
            //    transaction.description = x.description;
            //    vmCreateTransactions.Add(transaction);
            //});

            //if (vmCreateTransactions.Count() != 0)
            //{
            //    return new GetAccountTransactionQueryResponse
            //    {
            //        vmCreateTransactions = vmCreateTransactions,
            //    };
            //}
            //else 
            //{
            //    throw new Exception("Hesap Bulunamadı!..");
            //}
            
        }
    }
}
