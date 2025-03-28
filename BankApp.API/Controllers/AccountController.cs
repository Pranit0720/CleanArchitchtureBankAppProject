using BankApp.Application.Features.AccountFeature.Command.AddAccount;
using BankApp.Application.Features.AccountFeature.Command.DeleteAccount;
using BankApp.Application.Features.AccountFeature.Command.UpdateAccount;
using BankApp.Application.Features.AccountFeature.Query.GetAllAccounts;
using BankApp.Application.Features.AccountFeature.Query.GetAllAccountsById;
using BankApp.Application.ViewModels.AccountViewModels;
using BankApp.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        readonly IMediator _iMediatR;
        public AccountController(IMediator iMediator)
        {
            _iMediatR = iMediator;
        }

        [HttpGet("GetAllAccounts")]
        
        public async Task<IActionResult> GetAllAccounts()
        {
            var allAccounts= await _iMediatR.Send(new GetAllAccountsQuery());
            return Ok(allAccounts);
        }
        [HttpGet("GetAllAccountsById")]
        public async Task<IActionResult> GetAllAccountsById(int id)
        {
            var account = await _iMediatR.Send(new GetAllAccountsByIdQuery(id));
            return Ok(account);
        }
        [HttpPost("AddAccount")]
        public async Task<IActionResult> AddAccount(AccountAddModel accounts)
        {
            var account = await _iMediatR.Send(new AddAccountQuery(accounts));
            return Ok(account);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var account = await _iMediatR.Send(new DeleteAccountQuery(id));
            return Ok(account);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAccount(int id,AccountUpdateModel account)
        {
            
            var accounts = await _iMediatR.Send(new UpdateAccountQuery(id,account));
            return Ok(accounts);
        }

    }
}
