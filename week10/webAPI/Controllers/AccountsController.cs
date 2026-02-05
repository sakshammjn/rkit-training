using webAPI.Models;
using Microsoft.AspNetCore.Mvc;
using webAPI.Data;

namespace webAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        //returns all the accounts
        [HttpGet]
        public ActionResult<IEnumerable<Account>> GetAccounts()
        {
            return Ok(AccountDbContext.Current.Accounts);
        }

        //returns a single account detail
        [HttpGet("{id}")]
        public ActionResult<Account> GetAccount(int id)
        {
            var account = AccountDbContext.Current.Accounts.FirstOrDefault(a => a.Id == id);

            if (account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }
    }
}
