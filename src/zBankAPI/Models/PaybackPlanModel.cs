using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace zBankAPI.Models
{
    public class PaybackPlanModel
    {
        [Required]
        public float[,] paybackMonths { get; set; }
    }
}
