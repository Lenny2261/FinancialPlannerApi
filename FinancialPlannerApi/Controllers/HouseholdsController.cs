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
    public class HouseholdsController : ApiController
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// Get a household based on Id
        /// </summary>
        /// <param name="householdId">The household Id</param>
        /// <returns></returns>
        [Route("GetHousehold")]
        [AcceptVerbs("GET")]
        public async Task<Household> GetHousehold(int householdId)
        {
            return await db.GetHousehold(householdId);
        }
    }
}
