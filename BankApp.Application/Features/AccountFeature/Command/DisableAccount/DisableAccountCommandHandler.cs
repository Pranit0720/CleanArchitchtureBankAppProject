using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Application.Interfaces;
using MediatR;

namespace BankApp.Application.Features.AccountFeature.Command.DisableAccount
{
    public class DisableAccountCommandHandler:IRequestHandler<DisableAccountCommand, int>
    {
        readonly IAccountRepository _accountRepository;
        public DisableAccountCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<int> Handle(DisableAccountCommand request, CancellationToken cancellationToken)
        {
            return await _accountRepository.DisableAccount(request.accountId);
        }
    }
    
}
