using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zBankAPI.BusinessLogic;
using zBankAPI.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace zBankAPI.Controllers
{
    [ApiController]
    [Route("loan")]
    public class LoanController : ControllerBase
    {
        LoanBusinessLogic businessLogic = new LoanBusinessLogic();

        [HttpPost]
        [Authorize]
        public IActionResult calculateLoan([FromBody]LoanModel loanModel)
        {
            try
            {
                PaybackPlanModel paybackPlan = businessLogic.calculatePaybackPlan(loanModel);
                string jsonResponse = JsonConvert.SerializeObject(paybackPlan);
                return Ok(jsonResponse); 
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
