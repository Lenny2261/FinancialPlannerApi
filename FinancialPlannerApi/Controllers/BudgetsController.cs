using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using FinancialPlannerApi.Models;
using Newtonsoft.Json;

namespace FinancialPlannerApi.Controllers
{
    public class BudgetsController : ApiController
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// Gets the budget based on Id
        /// </summary>
        /// <param name="budgetId">The budget Id</param>
        /// <returns></returns>
        [Route("GetBudget")]
        [AcceptVerbs("GET")]
        public async Task<Budget> GetBudget(int budgetId)
        {
            return await db.GetBudget(budgetId);
        }

        /// <summary>
        /// Get all the categories for a budget
        /// </summary>
        /// <param name="budgetId">The budgets Id</param>
        /// <returns></returns>
        [Route("GetBudgetCategories")]
        [AcceptVerbs("GET")]
        public async Task<List<BudgetCategories>> GetBudgetCategories(int budgetId)
        {
            return await db.GetBudgetCategories(budgetId);
        }

        /// <summary>
        /// Get budget categories for a chart using json
        /// </summary>
        /// <param name="budgetId">The budget Id</param>
        /// <returns></returns>
        [Route("GetBudgetCategories/Json")]
        public async Task<IHttpActionResult> GetBudgetCategoriesJson(int budgetId)
        {
            var json = JsonConvert.SerializeObject(await db.GetBudgetCategories(budgetId));
            return Ok(json);
        }

        /// <summary>
        /// Adding a budget category to a budget
        /// </summary>
        /// <param name="categoryId">The category Id</param>
        /// <param name="budgetId">The budget it belongs to</param>
        /// <param name="amountDedicated">The amount that you budgeted for</param>
        /// <returns></returns>
        [Route("AddBudgetCategory")]
        [AcceptVerbs("POST")]
        public int AddBudgetCategory(int categoryId, int budgetId, float amountDedicated)
        {
            return db.AddBudgetCategory(categoryId, budgetId, amountDedicated);
        }

    }
}