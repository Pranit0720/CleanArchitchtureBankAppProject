using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Application.ViewModels.TransactionViewModel;
using MediatR;

namespace BankApp.Application.Features.TransactionFeature.Command.TransferTransaction
{
    public record TransferTransactionCommand(int accountId, TransactionTransferModel TransferModel):IRequest<int>;
    
}
