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
                Console.WriteLine("pb scheme " + loanModel.paybackScheme);
                throw new Exception("Invalid or not yet implemented payback scheme");
            }

            return paybackPlan;
        }

        private float[] seriesLoan(LoanModel loanModel) 
        {
            float interest = interestByLoanType(loanModel.loanType);
            int numberOfMonths = loanModel.paybackPeriod * 12;
            float monthlyPay = loanModel.loanAmount / numberOfMonths;

            float[] paybackMonths = new float[numberOfMonths];
            float restAmount = loanModel.loanAmount;
            for (int m = 0; m < numberOfMonths; m++) 
            {
                float monthlyInterest = (restAmount - monthlyPay) * interest;
                float payAndInterest = monthlyPay + monthlyInterest;

                paybackMonths[m] = payAndInterest;
                restAmount -= monthlyPay;
            }
            int x = 5;
            return paybackMonths;
        }

        private float interestByLoanType(String loanType)
        {
                    if (loanType.Equals("housing")) 
            {
                return 0.035f;
            }
            else 
            {
                Console.WriteLine("loan type " + loanType);

                throw new Exception("Invalid or not yet implemented loan type");
            }
        }

    }
}
