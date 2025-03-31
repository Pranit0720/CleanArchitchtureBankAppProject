using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Application.Exceptions;
using BankApp.Application.Interfaces;
using BankApp.Application.ViewModels.TransactionViewModel;
using BankApp.Domain;
using BankApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Infrastructure.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        readonly BankDBContext _bankDBContext;
        public TransactionRepository(BankDBContext bankDBContext)
        {
            _bankDBContext = bankDBContext;
        }


        public async Task<IEnumerable<Transactions>> GetAllTransactions()
        {
            return await _bankDBContext.Transaction.ToListAsync();
        }

        public async Task<IEnumerable<Transactions>> GetTransactionByAccountIdAsync(int accountId)
        {
            var transactions = await _bankDBContext.Transaction.Include(e => e.Accounts).Where(x => x.AccountId == accountId).ToListAsync();
            if (transactions.Count == 0)
            {
                throw new NotFoundException("Add some Transactions First");
            }
            return transactions;
        }

        public async Task<TransactionAddModel> AddTransactionAsync(int accountId, TransactionAddModel transactions)
        {
            var transaction = new Transactions
            {
                AccountId = accountId,
                TransactionType = transactions.TransactionType,
                Amount = transactions.Amount,
                Description = transactions.Description,
                Date = DateTime.Now


            };
            var account = await _bankDBContext.Account.FirstOrDefaultAsync(x => x.ID == accountId);
            if (account == null)
            {
                throw new NotFoundException($"Account Of id={accountId} not found!!!");
            }
            if (account.Balance < transaction.Amount)
            {
                throw new InsufficientBalance("Insufficient Balance!!!!");

            }
            account.Balance -= transaction.Amount;

            await _bankDBContext.AddAsync(transaction);
            await _bankDBContext.SaveChangesAsync();
            return transactions;
        }
    }
}
