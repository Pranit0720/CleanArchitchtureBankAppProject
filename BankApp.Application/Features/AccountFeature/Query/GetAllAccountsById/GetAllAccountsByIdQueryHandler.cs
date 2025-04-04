﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using BankApp.Application.Interfaces;
using BankApp.Domain;
using MediatR;

namespace BankApp.Application.Features.AccountFeature.Query.GetAllAccountsById
{
    public class GetAllAccountsByIdQueryHandler : IRequestHandler<GetAllAccountsByIdQuery, Accounts>
    {
        readonly IAccountRepository _accountRepository;
        public GetAllAccountsByIdQueryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Accounts> Handle(GetAllAccountsByIdQuery request, CancellationToken cancellationToken)
        {
            var GetAllAccountById = await _accountRepository.GetAccountByIdAsync(request.id);
            return GetAllAccountById;
        }






    }
}
