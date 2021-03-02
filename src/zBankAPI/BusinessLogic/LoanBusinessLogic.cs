using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zBankAPI.Models;

namespace zBankAPI.BusinessLogic
{
    public class LoanBusinessLogic
    {
        public PaybackPlanModel calculatePaybackPlan(LoanModel loanModel)
        {
            PaybackPlanModel paybackPlan = new PaybackPlanModel();

            if (loanModel.paybackScheme.Equals("series"))
            {
                paybackPlan.paybackMonths = seriesLoan(loanModel);
            } 
            else
            {
                throw new Exception("Invalid or not yet implemented payback scheme");
            }

            return paybackPlan;
        }

        // Method for calculating series loan
        public float[,] seriesLoan(LoanModel loanModel)
        {
            float interest = interestByLoanType(loanModel.loanType);
            int numberOfMonths = loanModel.paybackPeriod * 12;
            float monthlyPay = loanModel.loanAmount / numberOfMonths;

            float[,] paybackMonths = new float[numberOfMonths, 2];
            float restAmount = loanModel.loanAmount;
            for (int m = 0; m < numberOfMonths; m++)
            {
                float monthlyInterest = restAmount / 12 * interest;

                paybackMonths[m, 0] = monthlyPay;
                paybackMonths[m, 1] = monthlyInterest ;
                restAmount -= monthlyPay;
            }
            return paybackMonths;
        }

        public float interestByLoanType(String loanType)
        {
            if (loanType.Equals("housing")) 
            {
                // There would be a query to database here to get the interest of this kind of loan
                return 0.035f;
            }
            else 
            {
                throw new Exception("Invalid or not yet implemented loan type");
            }
        }

    }
}
