using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace zBankAPI.Models
{
    public class LoanModel
    {
        [Required]
        [Range(0, Double.MaxValue)]
        public float loanAmount { get; set; }

        [Required]
        [Range(0, Double.MaxValue)]
        public int paybackPeriod { get; set; }

        [Required]
        public string loanType { get; set; }

        [Required]
        public string paybackScheme { get; set; }
    }
}
