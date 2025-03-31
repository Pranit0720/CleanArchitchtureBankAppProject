using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Application.Interfaces;
using MediatR;

namespace BankApp.Application.Features.AccountFeature.Command.UpdateAccount
{
    public class UpdateCommandHandler : IRequestHandler<UpdateAccountCommand, int>
    {
        readonly IAccountRepository _accountRepository;
        public UpdateCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<int> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {

            return await _accountRepository.UpdateAccountAsync(request.id,request.accounts);
        }
    }
}
