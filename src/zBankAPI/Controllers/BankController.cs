using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zBankAPI.BusinessLogic;

namespace zBankAPI.Controllers
{
    public class BankController : ControllerBase
    {
        BankBusinessLogic businessLogic = new BankBusinessLogic();
    }
}
