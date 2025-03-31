using System.Security.Claims;
using BankApp.Application.Features.AccountFeature.Command.AddAccount;
using BankApp.Application.Features.AccountFeature.Command.DeleteAccount;
using BankApp.Application.Features.AccountFeature.Command.UpdateAccount;
using BankApp.Application.Features.AccountFeature.Query.GetAllAccounts;
using BankApp.Application.Features.AccountFeature.Query.GetAllAccountsById;
using BankApp.Application.ViewModels.AccountViewModels;
using BankApp.Domain;
using BankApp.Identity.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.API.Controllers
{
    [Authorize(Roles = "Administartor")]
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

        public async Task<IActionResult> GetAccountsAsync()
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
        //[Authorize(Roles = "User")]
        [HttpPost("AddAccount")]
        public async Task<IActionResult> AddAccount(AccountAddModel accounts)
        {
            var userId = User.FindFirstValue("userId");
            var account = await _iMediatR.Send(new AddAccountCommand(userId, accounts));
            return Ok(account);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var account = await _iMediatR.Send(new DeleteAccountCommand(id));
            return Ok(account);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAccount([FromQuery]int id,[FromBody]AccountUpdateModel account)
        {
            
            var accounts = await _iMediatR.Send(new UpdateAccountCommand(id,account));
            return Ok(accounts);
        }

    }
}
