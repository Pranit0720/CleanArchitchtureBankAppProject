using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Application.Interfaces;
using BankApp.Domain;
using MediatR;

namespace BankApp.Application.Features.AccountFeature.Command.AddAccount
{
    public class AddAccountQueryHandler : IRequestHandler<AddAccountQuery, Accounts>
    {
        readonly IAccountRepository _accountRepository;
        public AddAccountQueryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public  Task<Accounts> Handle(AddAccountQuery request, CancellationToken cancellationToken)
        {
            var account = _accountRepository.AddAccountAsync(request.Accounts);
            return account;
        }

        
    }
}
