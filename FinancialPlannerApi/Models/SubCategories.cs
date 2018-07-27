using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialPlannerApi.Models
{
    public class SubCategories
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }

    }
}