using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Application.Interfaces;
using MediatR;

namespace BankApp.Application.Features.AccountFeature.Command.UpdateAccount
{
    public class UpdateQueryHandler : IRequestHandler<UpdateAccountQuery, int>
    {
        readonly IAccountRepository _accountRepository;
        public UpdateQueryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<int> Handle(UpdateAccountQuery request, CancellationToken cancellationToken)
        {

            return await _accountRepository.UpdateAccountAsync(request.id,request.accounts);
        }
    }
}
