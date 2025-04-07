using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Application.ViewModels.AccountViewModels;
using BankApp.Application.ViewModels.TransactionViewModel;
using BankApp.Domain;

namespace BankApp.Application.Interfaces
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transactions>> GetAllTransactions();
        Task<IEnumerable<Transactions>> GetTransactionByAccountIdAsync(int accountId);
        Task<TransactionAddModel> AddTransactionAsync(int accountId,TransactionAddModel transactions);
        Task<int> TransferToAnotherAccountBuAccountNumber(int accountId, TransactionTransferModel transferModel);
        Task<int> DepositeMoney(int accountId,DepositeAmount deposite);
        //Task<int> UpdateTransactionAsync(int id, Transactions transactions);
        //Task<int> DeleteTransactionAsync(int transactionId);
    }
}
