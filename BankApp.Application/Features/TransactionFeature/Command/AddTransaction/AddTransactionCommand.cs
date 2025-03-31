using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Application.ViewModels.TransactionViewModel;
using MediatR;

namespace BankApp.Application.Features.TransactionFeature.Command.AddTransaction
{
    public record AddTransactionCommand(int accountId,TransactionAddModel TransactionAddModel):IRequest<TransactionAddModel>;
    
}
