using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BankApp.Application.Features.AccountFeature.Command.DisableAccount
{
    public record DisableAccountCommand(int accountId) : IRequest<int>;
    
}
