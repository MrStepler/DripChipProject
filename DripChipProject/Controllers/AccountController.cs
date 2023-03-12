using Microsoft.AspNetCore.Mvc;
using DripChipProject.Services;
using DripChipProject.Models;
using DripChipProject.Models.ResponseModels;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Security.Principal;

namespace DripChipProject.Controllers
{
    [Authorize]
    [ApiController]
    public class AccountController : Controller
    {
        IAccountService accountService;
        IAnimalsService animalsService;
        public AccountController(IAccountService service, IAnimalsService animalsService)
        {
            this.accountService = service;
            this.animalsService = animalsService;
        }
        [Route("accounts/{id}")]
        [HttpGet]
        public IActionResult GetAccountById(int? id)
        {

            if (id <= 0 || id == null)
            {
                return BadRequest();
            }
            if (accountService.GetAccount((int)id) == null)
            {
                return StatusCode(404);
            }
            return Ok(accountService.GetAccount((int)id));
        }
        [Route("accounts/search")]
        [HttpGet]
        public IActionResult SearchAccount([FromQuery] string? firstName, [FromQuery] string? lastName, [FromQuery] string? email, [FromQuery] int from = 0, [FromQuery] int size = 10)
        {
            if (from < 0)
            {
                return StatusCode(400);
            }
            if (size <= 0)
            {
                return StatusCode(400);
            }
            return Ok(accountService.SearchAccounts(firstName, lastName, email, from, size));
        }
        [Route("accounts/register")]
        [HttpPost]
        public IActionResult RegisterAccount(AccountRegistrationDTO account)
        {
            if (HttpContext.User.Identity.Name != "guest")
            {
                return StatusCode(403);
            }
            if (!IsValideData(account))
            {
                return StatusCode(400);
            }
            if (accountService.GetAccountByEmail(account.email) != null)
            {
                return StatusCode(409);
            }
            return Created("", accountService.AddAccount(account));
        }

        [Route("accounts/{accountId}")]
        [HttpPut]
        public IActionResult EditAccount(int accountId, [FromBody] AccountRegistrationDTO account)
        {
            if (HttpContext.User.Identity.Name == "guest")
            {
                return StatusCode(401);
            }
            
            if (accountService.GetAccount((int)accountId).email != HttpContext.User.Identity.Name)
            {
                return StatusCode(403);
            }
            if (accountService.GetAccount((int)accountId) == null)
            {
                return StatusCode(403);
            }
            if (accountService.GetAccountByEmail(account.email) != null)
            {
                return StatusCode(409);
            }
            if (!IsValideData(account))
            {
                return StatusCode(400);
            }
            return Ok(accountService.EditAccount(accountId, account));
        }

        [Route("accounts/{id}")]
        [HttpDelete]
        public IActionResult DeleteAccount(int? id) 
        {
            if (HttpContext.User.Identity.Name == "guest")
            {
                return StatusCode(401);
            }
            if (id == null || id <= 0)
            {
                return StatusCode(400);
            }
            if (animalsService.SearchAnimal(null,null,chipperId:id, null, null, null,0,10) != null)
            {
                return StatusCode(400);
            }
            if (accountService.GetAccount((int)id).email != HttpContext.User.Identity.Name)
            {
                return StatusCode(403);
            }
            if (accountService.GetAccount((int)id) == null)
            {
                return StatusCode(403);
            }
            accountService.DeleteAccount((int)id);
            return Ok();
        }
        private bool IsValideData(AccountRegistrationDTO account)
        {
            const string emailPattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
            if (string.IsNullOrWhiteSpace(account.firstName))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(account.lastName))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(account.password))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(account.email) || !Regex.IsMatch(account.email, emailPattern, RegexOptions.IgnoreCase))
            {
                return false;
            }
            return true;
        }
    }
}