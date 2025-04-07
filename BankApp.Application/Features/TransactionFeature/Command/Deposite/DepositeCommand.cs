using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Application.ViewModels.TransactionViewModel;
using MediatR;

namespace BankApp.Application.Features.TransactionFeature.Command.Deposite
{
    public record DepositeCommand(int accountId, DepositeAmount deposite):IRequest<int>;
    
}
