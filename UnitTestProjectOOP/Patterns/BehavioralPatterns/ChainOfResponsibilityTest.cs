using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP.Patterns.BehavioralPatterns.ChainOfResponsibility;

namespace UnitTestProjectOOP.Patterns.BehavioralPatterns
{
    [TestClass]
    public class ChainOfResponsibilityTest
    {
        [TestMethod]
        public void ReceiverBankTransferIsNotModified()
        {
            bool constValue = true;

            Receiver receiver1 = new Receiver(constValue, false, false);
            Receiver receiver2 = new Receiver(false, false, false) { BankTransfer = constValue };

            Assert.AreEqual(constValue, receiver1.BankTransfer);
            Assert.AreEqual(constValue, receiver2.BankTransfer);
        }

        [TestMethod]
        public void ReceiverMoneyTransferIsNotModified()
        {
            bool constValue = true;

            Receiver receiver1 = new Receiver(false, constValue, false);
            Receiver receiver2 = new Receiver(false, false, false) { MoneyTransfer = constValue };

            Assert.AreEqual(constValue, receiver1.MoneyTransfer);
            Assert.AreEqual(constValue, receiver2.MoneyTransfer);
        }

        [TestMethod]
        public void ReceiverPayPalTransferIsNotModified()
        {
            bool constValue = true;

            Receiver receiver1 = new Receiver(false, false, constValue);
            Receiver receiver2 = new Receiver(false, false, false) { PayPalTransfer = constValue };

            Assert.AreEqual(constValue, receiver1.PayPalTransfer);
            Assert.AreEqual(constValue, receiver2.PayPalTransfer);
        }

        [TestMethod]
        public void BankPaymentHandlerAreEqual()
        {
            string constResult = "Выполняем банковский перевод";
            Receiver receiver = new Receiver(true, false, false);
            string result;

            result = COF_Example.Instance.Main(receiver);

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void MoneyPaymentHandlerAreEqual()
        {
            string constResult = "Выполняем перевод через системы денежных переводов";
            Receiver receiver = new Receiver(false, true, false);
            string result;

            result = COF_Example.Instance.Main(receiver);

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void PayPalPaymentHandlerAreEqual()
        {
            string constResult = "Выполняем перевод через PayPal";
            Receiver receiver = new Receiver(false, false, true);
            string result;

            result = COF_Example.Instance.Main(receiver);

            Assert.AreEqual(constResult, result);
        }
    }
}
