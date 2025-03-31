using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BankApp.Application.Features.AccountFeature.Command.DeleteAccount
{
    public record DeleteAccountCommand(int id):IRequest<int>;
    
}
