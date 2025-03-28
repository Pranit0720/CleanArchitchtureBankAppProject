using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Application.Exceptions;
using BankApp.Application.Interfaces;
using MediatR;

namespace BankApp.Application.Features.AccountFeature.Command.DeleteAccount
{
    public class DeleteAccountQueryHandler : IRequestHandler<DeleteAccountQuery, int>
    {
        readonly IAccountRepository _accountRepository;
        public DeleteAccountQueryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<int> Handle(DeleteAccountQuery request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetAccountByIdAsync(request.id);
            if(account is  null)
            {
                throw new NotFoundException($"Account With {request.id} is not found!!");
            }
            return await _accountRepository.DeleteAccountAsync(account.ID);
        }
    }
}
