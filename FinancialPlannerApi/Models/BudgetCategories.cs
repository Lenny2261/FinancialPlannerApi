using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialPlannerApi.Models
{
    public class BudgetCategories
    {

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int BudgetId { get; set; }
        public double AmountDedicated { get; set; }

    }
}