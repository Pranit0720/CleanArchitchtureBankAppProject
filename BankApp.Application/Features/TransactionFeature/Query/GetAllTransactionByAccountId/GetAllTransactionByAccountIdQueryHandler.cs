using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Application.Interfaces;
using BankApp.Domain;
using MediatR;

namespace BankApp.Application.Features.TransactionFeature.Query.GetAllTransactionByAccountId
{
    public class GetAllTransactionByAccountIdQueryHandler : IRequestHandler<GetAllTransactionByAccountIdQuery, IEnumerable<Transactions>>
    {
        readonly ITransactionRepository _transactionRepository;
        public GetAllTransactionByAccountIdQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        async Task<IEnumerable<Transactions>> IRequestHandler<GetAllTransactionByAccountIdQuery, IEnumerable<Transactions>>.Handle(GetAllTransactionByAccountIdQuery request, CancellationToken cancellationToken)
        {

            return await _transactionRepository.GetTransactionByAccountIdAsync(request.accountId);
        }
    }
}
