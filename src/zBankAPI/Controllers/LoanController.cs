﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zBankAPI.BusinessLogic;
using zBankAPI.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;

namespace zBankAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowedOrigins")]
    public class LoanController : ControllerBase
    {
        LoanBusinessLogic businessLogic = new LoanBusinessLogic();

        [HttpPost]
        public IActionResult calculateLoan([FromBody]LoanModel loanModel)
        {
            Console.WriteLine("OUTER loan type " + loanModel.loanType);
            try 
            {
                PaybackPlanModel paybackPlan = businessLogic.calculatePaybackPlan(loanModel);
                string jsonResponse = JsonConvert.SerializeObject(paybackPlan);
                return Ok(jsonResponse); 
            } 
            catch (Exception e)
            {
                return BadRequest();
            }
        }

    }
}
