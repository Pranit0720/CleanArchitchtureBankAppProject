using System.Threading.Tasks;
using BankApp.Application.Features.AccountFeature.Query.GetAllAccountsById;
using BankApp.Application.Features.TransactionFeature.Command.AddTransaction;
using BankApp.Application.Features.TransactionFeature.Command.TransferTransaction;
using BankApp.Application.Features.TransactionFeature.Query.GetAllTransactionByAccountId;
using BankApp.Application.Features.TransactionFeature.Query.GetAllTransactions;
using BankApp.Application.ViewModels.TransactionViewModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.API.Controllers
{
    [Authorize(Roles ="User")]
    [Route("api/[controller]")]
    [ApiController]
    
    public class TransactionController : ControllerBase
    {
        readonly IMediator _iMediatR;
        public TransactionController(IMediator iMediator)
        {
            _iMediatR = iMediator;
        }

        [HttpGet("GetAllTransaction")]
        public async Task<IActionResult> GetAllTransactions()
        {
            var Transactions = await _iMediatR.Send(new GetAllTransactionsQuery());
            return Ok(Transactions);
        }
        [HttpGet("GetByAccountId")]
        public async Task<IActionResult> GetAllTransactionsByAccountID(int accountId)
        {
            var transaction= await _iMediatR.Send(new GetAllTransactionByAccountIdQuery(accountId));
            return Ok(transaction);
        }
        [HttpPost]
        public async Task<IActionResult> AddTransaction([FromQuery]int id,[FromBody]TransactionAddModel transactionAddModel)
        {
            var transaction = await _iMediatR.Send(new AddTransactionCommand(id, transactionAddModel));
            return Ok(transaction);
        }

        [HttpPost("Transfer")]

        public async Task<IActionResult> TransferAmount([FromQuery] int id, [FromBody] TransactionTransferModel transferModel)
        {
            var transaction = await _iMediatR.Send(new TransferTransactionCommand(id, transferModel));
            return Ok(transaction);
        }
    }
}
