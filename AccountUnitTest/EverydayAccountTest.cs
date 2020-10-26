using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ControllerApp;
using ControllerApp.Accounts;

namespace AccountUnitTest
{
    [TestClass]
    public class EverydayAccountTest
    {
        //Everyday tests 
        //
        //tests the deposit function in an everday account
        [TestMethod]
        public void DepositWithValidAmountEveryday()
        {
            float initialBalance = 200;
            float depositAmount = 50;
            float expected = 250;

            Customer customer = new Customer(4, "Allen", "02222222");
            EverydayAccount everydayAccount = new EverydayAccount(customer, 5, initialBalance);

            float actual = everydayAccount.Deposit(depositAmount);

            Assert.AreEqual(expected, actual);
        }
        //tests a failed deposit in an everyday account
        [TestMethod]
        public void DepositWithInvalidAmountEveryday()
        {
            float initialBalance = 200;
            float depositAmount = -50;

            Customer customer = new Customer(4, "Allen", "02222222");
            EverydayAccount everydayAccount = new EverydayAccount(customer, 5, initialBalance);

            try
            {
                everydayAccount.Deposit(depositAmount);
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
            Assert.Fail();
        }
        //tests a withdraw with a valid amount withdrew
        [TestMethod]
        public void WithdrawWithValidAmountEveryday()
        {
            float initialBalance = 200;
            float withdrawAmount = 50;
            float expected = 150;

            Customer customer = new Customer(4, "Allen", "02222222");
            EverydayAccount everydayAccount = new EverydayAccount(customer, 5, initialBalance);

            float actual = everydayAccount.Withdraw(withdrawAmount);

            Assert.AreEqual(expected, actual);
        }
        //tests a withdraw with a value larger than what is in the account
        [TestMethod]
        public void WithdrawWithInvalidAmountEveryday()
        {
            float initialBalance = 200;
            float withdrawAmount = 250;

            Customer customer = new Customer(4, "Allen", "02222222");
            EverydayAccount everydayAccount = new EverydayAccount(customer, 5, initialBalance);
            try
            {
                everydayAccount.Withdraw(withdrawAmount);
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
            Assert.Fail();
        }
        //tests a withdraw with a negative value
        [TestMethod]
        public void WithdrawWithLessThanZeroEveryday()
        {
            float initialBalance = 200;
            float withdrawAmount = -10;

            Customer customer = new Customer(4, "Allen", "02222222");
            EverydayAccount everydayAccount = new EverydayAccount(customer, 5, initialBalance);
            try
            {
                everydayAccount.Withdraw(withdrawAmount);
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
            Assert.Fail();
        }

        //Investment Test methods

        //tests the deposit function with a valid amount
        [TestMethod]
        public void DepositWithValidAmountInvestment()
        {
            float initialBalance = 200;
            float depositAmount = 50;
            float expected = 250;

            Customer customer = new Customer(4, "Allen", "02222222");
            InvestmentAccount investmentAccount = new InvestmentAccount(customer, 5, initialBalance, 5, 20);

            float actual = investmentAccount.Deposit(depositAmount);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        //tests deposit function with a invaild amount
        public void DepositWithInvalidAmountInvestment()
        {
            float initialBalance = 200;
            float depositAmount = -50;

            Customer customer = new Customer(4, "Allen", "02222222");
            InvestmentAccount investmentAccount = new InvestmentAccount(customer, 5, initialBalance,5, 20);

            try
            {
                investmentAccount.Deposit(depositAmount);
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
            Assert.Fail();
        }
        //tests the withdraw function with a valid amount
        [TestMethod]
        public void WithdrawWithValidAmountInvestment()
        {
            float initialBalance = 200;
            float withdrawAmount = 50;
            float expected = 150;

            Customer customer = new Customer(4, "Allen", "02222222");
            InvestmentAccount investmentAccount = new InvestmentAccount(customer, 5, initialBalance, 5, 20);

            float actual = investmentAccount.Withdraw(withdrawAmount);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        //tests the withdraw function with a value larger than whats in the account
        public void WithdrawWithInvalidAmountInvestment()
        {
            float initialBalance = 200;
            float withdrawAmount = 250;

            Customer customer = new Customer(4, "Allen", "02222222");
            InvestmentAccount investmentAccount = new InvestmentAccount(customer, 5, initialBalance, 5, 20);

            try
            {
                float actual = investmentAccount.Withdraw(withdrawAmount);
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
            Assert.Fail();
        }
     /*   [TestMethod]
        //
        public void WithdrawWithInvalidAmountAndLittleBalanceInvestment()
        {
            float initialBalance = 10;
            float withdrawAmount = 250;

            Customer customer = new Customer(4, "Allen", "02222222");
            InvestmentAccount investmentAccount = new InvestmentAccount(customer, 5, initialBalance, 5, 20);
            try
            {
                investmentAccount.Withdraw(withdrawAmount);
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }

            Assert.Fail();
        }*/
        //tests the withdraw function with a amount that is negative
        [TestMethod]
        public void WithdrawWithLessThanZeroInvestment()
        {
            float initialBalance = 200;
            float withdrawAmount = -10;

            Customer customer = new Customer(4, "Allen", "02222222");
            InvestmentAccount investmentAccount = new InvestmentAccount(customer, 5, initialBalance, 5, 20);
            try
            {
                investmentAccount.Withdraw(withdrawAmount);
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
            Assert.Fail();
        }
        //tests the calaculate invest function
        [TestMethod]
        public void CalculateInterestInvestment()
        {
            float initialBalance = 200;
            float expected = 210;

            Customer customer = new Customer(4, "Allen", "02222222");
            InvestmentAccount investmentAccount = new InvestmentAccount(customer, 5, initialBalance, 5, 20);

            float actual = investmentAccount.CalculateInterest();
            Console.WriteLine("actual "+ actual);
            Assert.AreEqual(expected, actual, 0.001);
        }

        //Omni Test methods

        //tests the deposit function with a valid amount
        [TestMethod]
        public void DepositWithValidAmountOmni()
        {
            float initialBalance = 200;
            float depositAmount = 50;
            float expected = 250;

            Customer customer = new Customer(4, "Allen", "02222222");
            OmniAccount omniAccount = new OmniAccount(customer, 5, initialBalance, 5, 20, 1000);

            float actual = omniAccount.Deposit(depositAmount);

            Assert.AreEqual(expected, actual);
        }
        //tests deposit function with a invaild amount
        [TestMethod]
        public void DepositWithInvalidAmountOmni()
        {
            float initialBalance = 200;
            float depositAmount = -50;

            Customer customer = new Customer(4, "Allen", "02222222");
            OmniAccount omniAccount = new OmniAccount(customer, 5, initialBalance, 5, 20, 1000);

            try
            {
                omniAccount.Deposit(depositAmount);
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
            Assert.Fail();
        }
        //tests the withdraw function with a valid amount
        [TestMethod]
        public void WithdrawWithValidAmountOmni()
        {
            float initialBalance = 200;
            float withdrawAmount = 50;
            float expected = 150;

            Customer customer = new Customer(4, "Allen", "02222222");
            OmniAccount omniAccount = new OmniAccount(customer, 5, initialBalance, 5, 20, 1000);

            float actual = omniAccount.Withdraw(withdrawAmount);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        //tests the withdraw function with a value larger than whats in the account
        public void WithdrawWithInvalidAmountOmni()
        {
            float initialBalance = 200;
            float withdrawAmount = 250;

            Customer customer = new Customer(4, "Allen", "02222222");
            OmniAccount omniAccount = new OmniAccount(customer, 5, initialBalance, 5, 20, 1000);

            try
            {
                omniAccount.Withdraw(withdrawAmount);
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
            Assert.Fail();
        }
        /* [TestMethod]
         //
         public void WithdrawWithInvalidAmountAndLittleBalanceOmni()
         {
             float initialBalance = 10;
             float withdrawAmount = 250;

             Customer customer = new Customer(4, "Allen", "02222222");
             OmniAccount omniAccount = new OmniAccount(customer, 5, initialBalance, 5, 20, 1000);
             try
             {
                 omniAccount.Withdraw(withdrawAmount);
             }
             catch (ArgumentOutOfRangeException)
             {
                 return;
             }

             Assert.Fail();
         }*/
        //tests the withdraw function with a amount that is negative
        [TestMethod]
        public void WithdrawWithLessThanZeroOmni()
        {
            float initialBalance = 200;
            float withdrawAmount = -10;

            Customer customer = new Customer(4, "Allen", "02222222");
            OmniAccount omniAccount = new OmniAccount(customer, 5, initialBalance, 5, 20, 1000);
            try
            {
                omniAccount.Withdraw(withdrawAmount);
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
            Assert.Fail();
        }
        [TestMethod]
        //tests the calaculate invest function
        public void CalculateInterestOmni()
        {
            float initialBalance = 200;
            float expected = 210;

            Customer customer = new Customer(4, "Allen", "02222222");
            OmniAccount omniAccount = new OmniAccount(customer, 5, initialBalance, 5, 20, 1000);

            float actual = omniAccount.CalculateInterest();

            Assert.AreEqual(expected, actual, 0.001);
        }
    }
}
