using System.Security.Claims;
using BankApp.Application.Features.AccountFeature.Command.AddAccount;
using BankApp.Application.Features.AccountFeature.Command.DeleteAccount;
using BankApp.Application.Features.AccountFeature.Command.DisableAccount;
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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        readonly IMediator _iMediatR;
        readonly UserManager<ApplicationUser> _userManager;
        public AccountController(IMediator iMediator, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _iMediatR = iMediator;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize(Roles = "Administartor")]
        [HttpGet("GetAllAccounts")]

        public async Task<IActionResult> GetAccountsAsync()
        {
            var allAccounts = await _iMediatR.Send(new GetAllAccountsQuery());
            return Ok(allAccounts);
        }
        [Authorize(Roles = "Administartor")]
        [HttpGet("GetAllAccountsById")]
        public async Task<IActionResult> GetAllAccountsById(int id)
        {
            var account = await _iMediatR.Send(new GetAllAccountsByIdQuery(id));
            return Ok(account);
        }
        [HttpPost("AddAccount")]
        public async Task<IActionResult> AddAccount(AccountAddModel accounts)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByEmailAsync(userId);


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
        public async Task<IActionResult> UpdateAccount([FromQuery] int id, [FromBody] AccountUpdateModel account)
        {

            var accounts = await _iMediatR.Send(new UpdateAccountCommand(id, account));
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

        [HttpPut("DisableAccount")]
        public async Task<IActionResult> DisableAccount([FromQuery]int accountId)
        {
            var account = await _iMediatR.Send(new DisableAccountCommand(accountId));
            return Ok(account);

        }
    }
}





















//if (!_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
//{
//    return Unauthorized();
//}
//var user = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value ?? null;
//if (user == null)
//{
//    return BadRequest("User not found");
//}