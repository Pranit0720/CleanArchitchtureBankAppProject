using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Application.ViewModels.AccountViewModels;
using BankApp.Domain;
using MediatR;

namespace BankApp.Application.Features.AccountFeature.Command.UpdateAccount
{
    public record UpdateAccountCommand(int id,AccountUpdateModel accounts):IRequest<int>;
    
}
