using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using BankApp.Application.DTO.AccountDto;
using BankApp.Application.ViewModels.AccountViewModels;
using BankApp.Domain;

namespace BankApp.Application.Interfaces
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Accounts>> GetAllAccounts();
        Task<Accounts> GetAccountByIdAsync(int id);  
        Task<Accounts> AddAccountAsync(Accounts accounts);
        Task<int> UpdateAccountAsync( int id,AccountUpdateModel accounts);
        Task<int> DeleteAccountAsync(int accountId);
    }
}
 