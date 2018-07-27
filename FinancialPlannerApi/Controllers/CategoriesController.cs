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
    public class CategoriesController : ApiController
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// Gets all categories
        /// </summary>
        /// <returns></returns>
        [Route("GetCategories")]
        [AcceptVerbs("GET")]
        public async Task<List<Categories>> GetCategories()
        {
            return await db.GetCategories();
        }

        /// <summary>
        /// Gets subcategories based on category Id
        /// </summary>
        /// <param name="categoryId">The category Id to search by</param>
        /// <returns></returns>
        [Route("GetSubCategories")]
        [AcceptVerbs("GET")]
        public async Task<List<SubCategories>> GetSubCategories(int categoryId)
        {
            return await db.GetSubCategories(categoryId);
        }
    }
}
