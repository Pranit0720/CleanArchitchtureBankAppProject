using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Domain;
using MediatR;

namespace BankApp.Application.Features.AccountFeature.Query.GetAllAccountsById
{
    internal class GetAllAccountsByIdQuery:IRequest<IEnumerable<Account>>;
}
