using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Application.Interfaces;
using BankApp.Domain;
using MediatR;

namespace BankApp.Application.Features.TransactionFeature.Query.GetAllTransactions
{
    public class GetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, IEnumerable<Transactions>>
    {
        readonly ITransactionRepository _transactionRepository;
        public GetAllTransactionsQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public Task<IEnumerable<Transactions>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
        {
            return _transactionRepository.GetAllTransactions();
        }
    }
}
