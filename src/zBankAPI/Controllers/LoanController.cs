using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zBankAPI.BusinessLogic;
using zBankAPI.Models;

namespace zBankAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoanController : ControllerBase
    {
        LoanBusinessLogic businessLogic = new LoanBusinessLogic();

        [HttpGet]
        public IActionResult calculateLoan([FromBody]LoanModel loanModel)
        {
            Console.WriteLine("OUTER loan type " + loanModel.loanType);
            try { 
                return Ok(businessLogic.calculatePaybackPlan(loanModel)); 
            } catch (Exception e)
            {
                return BadRequest();
            }
            
            //return Ok(loanModel);
        }

    }
}
