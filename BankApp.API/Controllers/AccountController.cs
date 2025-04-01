using System.Security.Claims;
using BankApp.Application.Features.AccountFeature.Command.AddAccount;
using BankApp.Application.Features.AccountFeature.Command.DeleteAccount;
using BankApp.Application.Features.AccountFeature.Command.UpdateAccount;
using BankApp.Application.Features.AccountFeature.Query.GetAccountsByUserId;
using BankApp.Application.Features.AccountFeature.Query.GetAllAccounts;
using BankApp.Application.Features.AccountFeature.Query.GetAllAccountsById;
using BankApp.Application.ViewModels.AccountViewModels;
using BankApp.Domain;
using BankApp.Identity.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.API.Controllers
{
    //[Authorize(Roles = "Administartor")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        readonly IMediator _iMediatR;
        readonly UserManager<ApplicationUser> _userManager;
        public AccountController(IMediator iMediator, UserManager<ApplicationUser> userManager)
        {
            _iMediatR = iMediator;
            _userManager = userManager;
        }

        [Authorize(Roles = "Administartor")]
        [HttpGet("GetAllAccounts")]

        public async Task<IActionResult> GetAccountsAsync()
        {
            var allAccounts= await _iMediatR.Send(new GetAllAccountsQuery());
            return Ok(allAccounts);
        }
        [Authorize(Roles = "Administartor")]
        [HttpGet("GetAllAccountsById")]
        public async Task<IActionResult> GetAllAccountsById(int id)
        {
            var account = await _iMediatR.Send(new GetAllAccountsByIdQuery(id));
            return Ok(account);
        }
        [Authorize(Roles = "User")]
        [HttpPost("AddAccount")]
        public async Task<IActionResult> AddAccount(AccountAddModel accounts)
        {
            var userId =  _userManager.GetUserId(User);
            var user= await _userManager.FindByEmailAsync(userId);


            var account = await _iMediatR.Send(new AddAccountCommand(user.Id, accounts));
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

        [HttpGet("MyAccounts")]
        public async Task<IActionResult> GetAllAccountsByUserId()
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByEmailAsync(userId);
            var account = await _iMediatR.Send(new GetAccountByUserIdQuery(user.Id));
            return Ok(account);
        }

    }
}
