using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using BankApp.Application.DTO.AccountDto;
using BankApp.Application.Interfaces;
using BankApp.Application.ViewModels.AccountViewModels;
using BankApp.Domain;
using BankApp.Identity.Models;
using BankApp.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Infrstructure.Repository
{
    internal class AccountRepository : IAccountRepository
    {
        readonly BankDBContext _bankDBContext;
        readonly UserManager<ApplicationUser> _userManager;
        public AccountRepository(BankDBContext bankDBContext, UserManager<ApplicationUser> userManager)
        {
            _bankDBContext = bankDBContext;
            _userManager = userManager;
        }

        public async Task<IEnumerable<Accounts>> GetAllAccounts()
        {
            return await _bankDBContext.Account.ToListAsync();
        }

        public async Task<IEnumerable<Accounts>> GetAccountByUserIdAsync(string id)
        {
            var list = await _bankDBContext.Account.Where(s => s.UserId == id).ToListAsync();
            return list;
        }

        public async Task<AccountAddModel> AddAccountAsync(string uId, AccountAddModel accounts)
        {
            //var user = await _userManager.GetUserId();
            var addAccount = new Accounts
            {
                UserId = uId,
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

        public async Task<Accounts> GetAccountByIdAsync(int id)
        {
            return await _bankDBContext.Account.FirstOrDefaultAsync(i => i.ID == id);
        }
    }
}
