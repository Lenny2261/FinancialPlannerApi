using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Description;
using FinancialPlannerApi.Models;
using Newtonsoft.Json;

namespace FinancialPlannerApi.Controllers
{
    public class AccountsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// Get all accounts
        /// </summary>
        /// <returns></returns>
        [Route("GetAccounts")]
        [AcceptVerbs("GET")]
        public async Task<List<Account>> GetAccounts()
        {
            return await db.GetAccounts();
        }

        /// <summary>
        /// Gets the json version of the accounts
        /// </summary>
        /// <returns></returns>
        [Route("GetAccounts/Json")]
        public async Task<IHttpActionResult> GetAccountsJson()
        {
            var json = JsonConvert.SerializeObject(await db.GetAccounts());
            return Ok(json);
        }

        /// <summary>
        /// Get an account based off of it's ID
        /// </summary>
        /// <param name="accountId">The account Id</param>
        /// <returns></returns>
        [Route("GetAccount")]
        [AcceptVerbs("GET")]
        public async Task<Account> GetAccount(int accountId)
        {
            return await db.GetAccount(accountId);
        }

        /// <summary>
        /// Gets all account types
        /// </summary>
        /// <returns></returns>
        [Route("GetAccountTypes")]
        [AcceptVerbs("GET")]
        public async Task<List<AccountType>> GetAccountTypes()
        {
            return await db.GetAccountTypes();
        }

        /// <summary>
        /// Add an account to a house
        /// </summary>
        /// <param name="name">The Name of the account</param>
        /// <param name="balance">The starting balance</param>
        /// <param name="interestRate">The interest rate</param>
        /// <param name="accountTypeId">The type of account it is</param>
        /// <param name="householdId">The household it's apart of</param>
        /// <returns></returns>
        [Route("AddAccount")]
        [AcceptVerbs("POST")]
        public async Task<int> AddAccount(string name, float balance, decimal interestRate, int accountTypeId, int householdId)
        {
            return await db.AddAccount(name, balance, interestRate, accountTypeId, householdId);
        }
    }
}