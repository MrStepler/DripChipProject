using Microsoft.AspNetCore.Mvc;
using DripChipProject.Services;
using DripChipProject.Models;
using DripChipProject.Models.ResponseModels;
using System.Text.RegularExpressions;

namespace DripChipProject.Controllers
{
    
    [Route("[controller]/[action]")]
    [ApiController]
    public class AccountController : Controller
    {
        IAccountService accountService;
        public AccountController(IAccountService service) 
        {
            this.accountService = service;
        }
        [HttpGet("{id}")]
        public IActionResult GetAccountById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            if (accountService.GetAccount(id) == null)
            {
                return StatusCode(404);
            }
            return Ok(accountService.GetAccount(id));
        }
        [HttpGet("search")]
        public IActionResult SearchAccount()
        {
            string? firstName = Request.Query["firstName"];
            string? lastName = Request.Query["lastName"];
            string? email = Request.Query["email"];
            int from = Convert.ToInt32(Request.Query["from"]);
            int size = Convert.ToInt32(Request.Query["size"]);
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
        [HttpPost("register")]
        public IActionResult RegisterAccount(AccountRegistrationDTO account)
        {

            string emailPattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
            String spaces = @"\s+";
            if (account.firstName == null || Regex.IsMatch(account.firstName, spaces) )
            {
                return StatusCode(400);
            }
            if (account.lastName == null || Regex.IsMatch(account.lastName, spaces))
            {
                return StatusCode(400);
            }
            if (account.password == null || Regex.IsMatch(account.password, spaces))
            {
                return StatusCode(400);
            }
            if (account.email == null || !Regex.IsMatch(account.email, emailPattern, RegexOptions.IgnoreCase) || Regex.IsMatch(account.email, spaces))
            {
                return StatusCode(400);
            }
            if (accountService.GetAccountByEmail(account.email) != null)
            {
                return StatusCode(409);
            }
            return Ok(accountService.AddAccount(account));
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAccount(int id) 
        {
            if (id == null)
            {
                return StatusCode(400);
            }
            accountService.DeleteAccount(id);
            return Ok();
        }
    }
}