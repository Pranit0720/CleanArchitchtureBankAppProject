using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Domain;

namespace BankApp.Application.Interfaces
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAllAccounts();
        Task<Account> GetAccountByIdAsync(int id);  
        Task<int> AddAccountAsync();
        Task<int> UpdateAccountAsync(int accountId, Account account);
        Task<int> DeleteAccountAsync(int accountId);
    }
}
 