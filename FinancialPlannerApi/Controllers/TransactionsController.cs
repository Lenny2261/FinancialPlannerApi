using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using FinancialPlannerApi.Models;
using System.Web.Http;
using System.Threading.Tasks;

namespace FinancialPlannerApi.Controllers
{
    public class TransactionsController : ApiController
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// Gets one transaction based on Id
        /// </summary>
        /// <param name="transactionID">The transaction Id</param>
        /// <returns></returns>
        [Route("GetTransaction")]
        [AcceptVerbs("GET")]
        public async Task<Transaction> GetTransaction(int transactionID)
        {
            return await db.GetTransaction(transactionID);
        }

        /// <summary>
        /// Gets all transactions for an account
        /// </summary>
        /// <param name="accountID">The accounts Id</param>
        /// <returns></returns>
        [Route("GetTransactions")]
        [AcceptVerbs("GET")]
        public async Task<List<Transaction>> GetTransactions(int accountID)
        {
            return await db.GetTransactions(accountID);
        }

        /// <summary>
        /// Gets all transaction types
        /// </summary>
        /// <returns></returns>
        [Route("GetTransactionTypes")]
        [AcceptVerbs("GET")]
        public async Task<List<TransactionType>> GetTransactionTypes()
        {
            return await db.GetTransactionTypes();
        }

        /// <summary>
        /// Gets all transaction statuses
        /// </summary>
        /// <returns></returns>
        [Route("GetTransactionStatuses")]
        [AcceptVerbs("GET")]
        public async Task<List<TransactionStatus>> GetTransactionStatuses()
        {
            return await db.GetTransactionStatuses();
        }

        /// <summary>
        /// Add a transactions
        /// </summary>
        /// <param name="description">The description</param>
        /// <param name="from">Where it's from</param>
        /// <param name="date">The date it happened</param>
        /// <param name="amount">The amount of the transaction</param>
        /// <param name="accountId">The account it's from</param>
        /// <param name="transactionTypeId">The type it is</param>
        /// <param name="subCategoryId">The sub category</param>
        /// <param name="transactionStatusId">The status of the transaction</param>
        /// <returns></returns>
        [Route("AddTransaction")]
        [AcceptVerbs("POST")]
        public int AddTransaction(string description, string from, DateTimeOffset date, float amount, int accountId, int transactionTypeId,
            int subCategoryId, int transactionStatusId)
        {
            return db.AddTransaction(description, from, date, amount, accountId, transactionTypeId, subCategoryId, transactionStatusId);
        }
    }
}
