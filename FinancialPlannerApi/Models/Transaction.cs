using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialPlannerApi.Models
{
    public class Transaction
    {

        public int Id { get; set; }
        public string Description { get; set; }
        public string From { get; set; }
        public DateTimeOffset Date { get; set; }
        public double Amount { get; set; }
        public int AccountId { get; set; }
        public int TransactionTypeId { get; set; }
        public int SubCategoryId { get; set; }
        public int TransactionStatusId { get; set; }

    }
}