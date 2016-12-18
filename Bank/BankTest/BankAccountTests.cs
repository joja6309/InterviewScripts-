using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS; 

namespace BankTest
{
    [TestClass]
    public class BankAccountTests
    {
        private TestContext testContextInstance;
        

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

      

        [TestMethod]
        public void Debit_WithValidAmount_UpdateBalance()
        {
            //arrange 
            double beggingBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 16.54;
            BankAccount account = new BankAccount("Mr. Bryan Walton",beggingBalance);
            account.Debit(debitAmount);
            double actual = account.Balance;
            TestContext.WriteLine(Convert.ToString(actual));
            TestContext.WriteLine(Convert.ToString(expected));
            TestContext.WriteLine(Convert.ToString(debitAmount));

            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
           
        }
        //unit test method
        [TestMethod]

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {

            // arrange
            double beginningBalance = 11.99;
            double debitAmount = 20.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act
            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }
            Assert.Fail("No exception was thrown.");

        }



    }
}
