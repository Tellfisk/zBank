using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zBankAPI.Models
{
    public class LoanModel
    {
        public float loanAmount { get; set; }
        public int paybackPeriod { get; set; }
        public string loanType { get; set; }
        public string paybackScheme { get; set; }
    }
}
