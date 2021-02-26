using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zBankAPI.Models
{
    public class PaybackPlanModel
    {
        public Dictionary<int, float[]> paybackMonths { get; set; }
    }
}
