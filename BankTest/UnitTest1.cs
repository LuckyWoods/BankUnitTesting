/*
* Author: Lucky Jaxxon Woods
* Date: 4/25/22
* File: UnitTest1.cs
* Description: A C# file containing the implementation of UnitTest1
*
*/
using BankAccountNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BankTest
{
    [TestClass]
    public class UnitTest1
    {

        // unit test code

        // ValidAmount Unit Tests
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act  
            account.Debit(debitAmount);

            // assert  
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }
        [TestMethod]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            // arrange  
            double beginningBalance = 11.99;
            double creditAmount = 4.55;
            double expected = 16.54;
            BankAccount account = new BankAccount("Mr. Lucky Woods", beginningBalance);

            // act  
            account.Credit(creditAmount);

            // assert  
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }


        //Frozen Unit Test

        [TestMethod]
        public void Credit_Frozen()
        {
            // arrange  
            double beginningBalance = 11.99;
            double creditAmount = 4.55;
            BankAccount account = new BankAccount("Mr. Lucky Woods", beginningBalance);

            
            // assert  
            account.ToggleFreeze();
            try
            {
                account.Credit(creditAmount);
            }

            catch (Exception e)
            {
                // assert  
                StringAssert.Contains(e.Message, "Account frozen");
                return;
            }
            Assert.Fail("No exception was thrown.");
        }


        //Less than Unit Tests.

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act  
            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // assert  
                StringAssert.Contains(e.Message, BankAccount.DebitAmountLessThanZeroMessage);
                return;
            }
            Assert.Fail("No exception was thrown.");
        }

        [TestMethod]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Credit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // arrange  
            double beginningBalance = 11.99;
            double creditAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Lucky Woods", beginningBalance);

            // act  
            try
            {
                account.Credit(creditAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // assert  
                StringAssert.Contains(e.Message, BankAccount.CreditAmountLessThanZeroMessage);
                return;
            }
            Assert.Fail("No exception was thrown.");
        }



        //More than Unit Tests.

        [TestMethod]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WhenAmountIsMoreThanZero_ShouldThrowArgumentOutOfRange()
        {
            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = 100.00;
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
