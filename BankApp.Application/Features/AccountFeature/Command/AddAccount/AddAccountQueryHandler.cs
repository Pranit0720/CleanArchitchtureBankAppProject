using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Application.Interfaces;
using BankApp.Application.ViewModels.AccountViewModels;
using BankApp.Domain;
using MediatR;

namespace BankApp.Application.Features.AccountFeature.Command.AddAccount
{
    public class AddAccountQueryHandler : IRequestHandler<AddAccountQuery, AccountAddModel>
    {
        readonly IAccountRepository _accountRepository;
        public AddAccountQueryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<AccountAddModel> Handle(AddAccountQuery request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.AddAccountAsync(request.Accounts);
            return account;
        }

        
    }
}
