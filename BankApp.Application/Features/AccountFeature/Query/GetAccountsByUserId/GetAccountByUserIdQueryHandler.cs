using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Application.Interfaces;
using BankApp.Domain;
using MediatR;

namespace BankApp.Application.Features.AccountFeature.Query.GetAccountsByUserId
{
    public class GetAccountByUserIdQueryHandler : IRequestHandler<GetAccountByUserIdQuery, IEnumerable<Accounts>>
    {
        readonly IAccountRepository _accountRepository;
        public GetAccountByUserIdQueryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<IEnumerable<Accounts>> Handle(GetAccountByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _accountRepository.GetAccountByUserIdAsync(request.uId);
        }
    }
}
