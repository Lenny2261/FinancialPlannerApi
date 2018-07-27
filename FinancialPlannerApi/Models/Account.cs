using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialPlannerApi.Models
{
    public class Account
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public double CurrentBalance { get; set; }
        public DateTimeOffset Created { get; set; }
        public decimal? InterestRate { get; set; }
        public int AccountTypeId { get; set; }
        public int? BudgetId { get; set; }
        public int HouseholdId { get; set; }
        public bool IsDeleted { get; set; }

    }
}