using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FinancialPlannerApi.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        
        public int AddTransaction(string description, string from, DateTimeOffset date, float amount, int accountId, int transactionTypeId,
            int subCategoryId, int transactionStatusId)
        {
            return Database.ExecuteSqlCommand("AddTransaction @description, @from, @date, @amount, @accountId, @transactionTypeId," +
                " @subCategoryId, @transactionTypeId",
                new SqlParameter("description", description),
                new SqlParameter("from", from),
                new SqlParameter("date", date),
                new SqlParameter("amount", amount),
                new SqlParameter("accountId", accountId),
                new SqlParameter("transactionTypeId", transactionTypeId),
                new SqlParameter("subCategoryId", subCategoryId),
                new SqlParameter("transactionStatusId", transactionStatusId));
        }

        public async Task<int> AddAccount(string name, float balance, decimal interestRate, int accountTypeId,
            int householdId)
        {
            float test = 0;
            Database.ExecuteSqlCommand("AddBudget @amount",
                new SqlParameter("amount", test));
            DateTimeOffset created = DateTime.Now;
            Budget budget = await Database.SqlQuery<Budget>("LastBudgetId").FirstOrDefaultAsync();
            return Database.ExecuteSqlCommand("AddAccount @name, @balance, @created, @interestRate, @accountTypeId, @budgetId, @householdId, @currentBalance",
                new SqlParameter("name", name),
                new SqlParameter("balance", balance),
                new SqlParameter("created", created),
                new SqlParameter("interestRate", interestRate),
                new SqlParameter("accountTypeId", accountTypeId),
                new SqlParameter("budgetId", budget.Id),
                new SqlParameter("householdId", householdId),
                new SqlParameter("currentBalance", balance));
        }

        public int AddBudgetCategory(int categoryId, int budgetId, float amountDedicated)
        {
            return Database.ExecuteSqlCommand("AddBudgetCategory @categoryId, @budgetId, @amountDedicated",
                new SqlParameter("categoryId", categoryId),
                new SqlParameter("budgetId", budgetId),
                new SqlParameter("amountDedicated", amountDedicated));
        }

        public async Task<List<Account>> GetAccounts()
        {
            return await Database.SqlQuery<Account>("GetAccounts").ToListAsync();
        }

        public async Task<List<AccountType>> GetAccountTypes()
        {
            return await Database.SqlQuery<AccountType>("GetAccountTypes").ToListAsync();
        }

        public async Task<Account> GetAccount(int accountId)
        {
            return await Database.SqlQuery<Account>("GetAccount @accountId",
                new SqlParameter("accountId", accountId)).FirstOrDefaultAsync();
        }

        public async Task<Budget> GetBudget(int budgetId)
        {
            return await Database.SqlQuery<Budget>("GetBudget @budgetId",
                new SqlParameter("budgetId", budgetId)).FirstOrDefaultAsync();
        }

        public async Task<List<BudgetCategories>> GetBudgetCategories(int budgetId)
        {
            return await Database.SqlQuery<BudgetCategories>("GetBudgetCategories @budgetId",
                new SqlParameter("budgetId", budgetId)).ToListAsync();
        }

        public async Task<Household> GetHousehold(int householdId)
        {
            return await Database.SqlQuery<Household>("GetHouseholds @householdId",
                new SqlParameter("householdId", householdId)).FirstOrDefaultAsync();
        }

        public async Task<List<Transaction>> GetTransactions(int accountId)
        {
            return await Database.SqlQuery<Transaction>("GetTransactions @accountId",
                new SqlParameter("accountId", accountId)).ToListAsync();
        }

        public async Task<Transaction> GetTransaction(int transactionId)
        {
            return await Database.SqlQuery<Transaction>("GetTransaction @transactionId",
                new SqlParameter("transactionId", transactionId)).FirstOrDefaultAsync();
        }

        public async Task<List<TransactionType>> GetTransactionTypes()
        {
            return await Database.SqlQuery<TransactionType>("GetTransactionTypes").ToListAsync();
        }

        public async Task<List<TransactionStatus>> GetTransactionStatuses()
        {
            return await Database.SqlQuery<TransactionStatus>("GetTransactionStatuses").ToListAsync();
        }

        public async Task<List<Categories>> GetCategories()
        {
            return await Database.SqlQuery<Categories>("GetCategories").ToListAsync();
        }

        public async Task<List<SubCategories>> GetSubCategories(int categoryId)
        {
            return await Database.SqlQuery<SubCategories>("GetSubCategories @categoryId",
                new SqlParameter("categoryId", categoryId)).ToListAsync();
        }

        //[Route("AddAcount")]
        //[AcceptVerbs("GET,POST")]

    }
}