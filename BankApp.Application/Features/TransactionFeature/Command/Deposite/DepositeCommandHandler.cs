using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Application.Interfaces;
using MediatR;

namespace BankApp.Application.Features.TransactionFeature.Command.Deposite
{
    public class DepositeCommandHandler : IRequestHandler<DepositeCommand, int>
    {
        readonly ITransactionRepository _transactionRepository;
        public DepositeCommandHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public async Task<int> Handle(DepositeCommand request, CancellationToken cancellationToken)
        {
            return await _transactionRepository.DepositeMoney(request.accountId, request.deposite);

        }
    }
}
