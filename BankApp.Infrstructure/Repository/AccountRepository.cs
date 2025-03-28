using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using BankApp.Application.DTO.AccountDto;
using BankApp.Application.Interfaces;
using BankApp.Application.ViewModels.AccountViewModels;
using BankApp.Domain;
using BankApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Infrstructure.Repository
{
    internal class AccountRepository : IAccountRepository
    {
        readonly BankDBContext _bankDBContext;
        public AccountRepository(BankDBContext bankDBContext)
        {
            _bankDBContext = bankDBContext;
        }

        public async Task<IEnumerable<Accounts>> GetAllAccounts()
        {
            return await _bankDBContext.Account.ToListAsync();
        }

        public async Task<Accounts> GetAccountByIdAsync(int id)
        {
            return await _bankDBContext.Account.FirstOrDefaultAsync(s => s.ID == id);

        }

        public async Task<AccountAddModel> AddAccountAsync(AccountAddModel accounts)
        {
            var addAccount = new Accounts
            {
                UserId = "1",
                AccountNumber = accounts.AccountNumber,
                Balance = accounts.Balance,
                AccountTypes = accounts.AccountTypes,
                CreatedDate = DateTime.Now

            };
            await _bankDBContext.Account.AddAsync(addAccount);
            await _bankDBContext.SaveChangesAsync();
            return accounts;
        }

        public async Task<int> DeleteAccountAsync(int accountId)
        {
            var account1 = await GetAccountByIdAsync(accountId);
            if (account1 != null)
            {
                _bankDBContext.Account.Remove(account1);
                return await _bankDBContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> UpdateAccountAsync(int id,AccountUpdateModel accounts)
        {
            var updateaccount = await GetAccountByIdAsync(id);
            if (updateaccount == null)
            {
                throw new DllNotFoundException($"Account id {id} not found!!");
            }
            updateaccount.Balance = accounts.Balance;
            updateaccount.AccountTypes = accounts.AccountTypes;
            _bankDBContext.Account.Update(updateaccount);
            return await _bankDBContext.SaveChangesAsync();
        }
    }
}
