using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using zBankAPI.BusinessLogic;
using zBankAPI.Models;

namespace zBankAPI.UnitTests
{
    [TestClass]
    public class LoanBusinessLogicTests
    {
        [TestMethod]
        [ExpectedException(typeof(Exception),
        "Invalid loan type was accepted")]
        public void interestByLoanType_LoanTypeDoesNotExist_ThrowsException()
        {
            LoanBusinessLogic businessLogic = new LoanBusinessLogic();
            businessLogic.interestByLoanType("someFakeLoanType");
        }

        [TestMethod]
        public void interestByLoanType_LoanTypeIsHousing_ReturnsCorrectValue()
        {
            LoanBusinessLogic businessLogic = new LoanBusinessLogic();

            float result = businessLogic.interestByLoanType("housing");

            Assert.AreEqual(result, 0.035f);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
        "Invalid payback scheme was accepted")]
        public void calculatePaybackPlan_PaybackSchemeDownNotExist_ThrowsException()
        {
            LoanBusinessLogic businessLogic = new LoanBusinessLogic();

            businessLogic.calculatePaybackPlan(new LoanModel 
            { loanAmount = 10, paybackPeriod = 1, loanType = "housing", paybackScheme = "someFakePaybackScheme" });

        }

    }
}
