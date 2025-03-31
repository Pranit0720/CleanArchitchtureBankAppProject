using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Application.Interfaces;
using BankApp.Application.ViewModels.TransactionViewModel;
using MediatR;

namespace BankApp.Application.Features.TransactionFeature.Command.AddTransaction
{
    public class AddTransactionCommandHandler : IRequestHandler<AddTransactionCommand, TransactionAddModel>
    {
        readonly ITransactionRepository _transactionRepository;
        public AddTransactionCommandHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public async Task<TransactionAddModel> Handle(AddTransactionCommand request, CancellationToken cancellationToken)
        {
            return await _transactionRepository.AddTransactionAsync(request.accountId, request.TransactionAddModel);
        }
    }
}
