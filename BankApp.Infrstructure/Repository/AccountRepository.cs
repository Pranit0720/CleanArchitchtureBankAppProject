using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Application.Interfaces;
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


        public Task<int> AddAccountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAccountAsync(int accountId)
        {
            throw new NotImplementedException();
        }

        public async Task<Accounts> GetAccountByIdAsync(int id)
        {
            return await _bankDBContext.Account.FirstOrDefaultAsync(s => s.ID == id);
        }

        

        public Task<int> UpdateAccountAsync(int accountId, Accounts account)
        {
            throw new NotImplementedException();
        }
    }
}
