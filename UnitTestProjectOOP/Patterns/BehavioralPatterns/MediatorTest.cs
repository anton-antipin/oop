using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP.Patterns.BehavioralPatterns.Mediator;

namespace UnitTestProjectOOP.Patterns.BehavioralPatterns
{
    [TestClass]
    public class MediatorTest
    {
        [TestMethod]
        public void ManagerMediatorPropertyIsNotModified()
        {
            ManagerMediator manager = new ManagerMediator();
            ColleagueDev customer = new CustomerCollegue(manager);
            ColleagueDev resultCustomer;
            ColleagueDev programmer = new ProgrammerCollegue(manager);
            ColleagueDev resultProgrammer;
            ColleagueDev tester = new TesterCollegue(manager);
            ColleagueDev resultTester;

            manager.Customer = customer;
            manager.Programmer = programmer;
            manager.Tester = tester;

            resultCustomer = manager.Customer;
            resultProgrammer = manager.Programmer;
            resultTester = manager.Tester;

            Assert.AreEqual(customer, resultCustomer);
            Assert.AreEqual(programmer, resultProgrammer);
            Assert.AreEqual(tester, resultTester);
        }

        [TestMethod]
        public void CustomerCollegueNotifyAreEqual()
        {
            string message = "Привет";
            string constResult = string.Format("Сообщение заказчику - {0}", message);
            ManagerMediator manager = new ManagerMediator();
            ColleagueDev customer = new CustomerCollegue(manager);
            string result;

            result = customer.Notify(message);

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void ProgrammerCollegueNotifyAreEqual()
        {
            string message = "Привет";
            string constResult = string.Format("Сообщение программисту - {0}", message);
            ManagerMediator manager = new ManagerMediator();
            ColleagueDev customer = new ProgrammerCollegue(manager);
            string result;

            result = customer.Notify(message);

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void TesterCollegueNotifyAreEqual()
        {
            string message = "Привет";
            string constResult = string.Format("Сообщение тестеру - {0}", message);
            ManagerMediator manager = new ManagerMediator();
            ColleagueDev customer = new TesterCollegue(manager);
            string result;

            result = customer.Notify(message);

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void CustomerCollegueSendAreEqual()
        {
            string message = "Привет";
            string constResult = string.Format("Сообщение программисту - {0}", message);
            ManagerMediator manager = new ManagerMediator();
            ColleagueDev customer = new CustomerCollegue(manager);
            ColleagueDev programmer = new ProgrammerCollegue(manager);
            ColleagueDev tester = new TesterCollegue(manager);
            manager.Customer = customer;
            manager.Programmer = programmer;
            manager.Tester = tester;
            string result;

            result = M_Example.Instance.Main(customer, message);

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void ProgrammerCollegueSendAreEqual()
        {
            string message = "Привет";
            string constResult = string.Format("Сообщение тестеру - {0}", message);
            ManagerMediator manager = new ManagerMediator();
            ColleagueDev customer = new CustomerCollegue(manager);
            ColleagueDev programmer = new ProgrammerCollegue(manager);
            ColleagueDev tester = new TesterCollegue(manager);
            manager.Customer = customer;
            manager.Programmer = programmer;
            manager.Tester = tester;
            string result;

            result = M_Example.Instance.Main(programmer, message);

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void TesterCollegueSendAreEqual()
        {
            string message = "Привет";
            string constResult = string.Format("Сообщение заказчику - {0}", message);
            ManagerMediator manager = new ManagerMediator();
            ColleagueDev customer = new CustomerCollegue(manager);
            ColleagueDev programmer = new ProgrammerCollegue(manager);
            ColleagueDev tester = new TesterCollegue(manager);
            manager.Customer = customer;
            manager.Programmer = programmer;
            manager.Tester = tester;
            string result;

            result = M_Example.Instance.Main(tester, message);

            Assert.AreEqual(constResult, result);
        }
    }
}
