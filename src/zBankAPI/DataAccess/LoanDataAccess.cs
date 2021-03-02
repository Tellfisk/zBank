using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace zBankAPI.DataAccess
{
    public class LoanDataAccess 
    {
        // Database query code to be used in the business logic
    }

    public class LoanType 
    {
        public int Id { get; set; }
        public String loanName { get; set; }
        public float interest { get; set; }
    }


    public class LoanDBContext : DbContext
    {
        public LoanDBContext() : base("LoanContext")
        {
        }

        public DbSet<LoanType> Loans { get; set; }
    }
}
