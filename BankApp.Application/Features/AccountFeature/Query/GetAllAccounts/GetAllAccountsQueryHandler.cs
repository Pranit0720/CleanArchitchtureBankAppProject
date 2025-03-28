using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Application.Interfaces;
using BankApp.Domain;
using MediatR;

namespace BankApp.Application.Features.AccountFeature.Query.GetAllAccounts
{
    public class GetAllAccountsQueryHandler : IRequestHandler<GetAllAccountsQuery, IEnumerable<Accounts>>
    {
        readonly IAccountRepository _accountRepository;
        public GetAllAccountsQueryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<IEnumerable<Accounts>> Handle(GetAllAccountsQuery request, CancellationToken cancellationToken)
        {
            var allAccount=await _accountRepository.GetAllAccounts();
            return allAccount;

        }
    }
}
