using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP.Patterns.BehavioralPatterns.Visitor;

namespace UnitTestProjectOOP.Patterns.BehavioralPatterns
{
    [TestClass]
    public class VisitorTest
    {
        [TestMethod]
        public void CompanyPropertyIsNotModified()
        {
            string constName = "1";
            string constNumber = "2";
            string constRegNumber = "3";
            Company company = new Company() { Name = constName, Number = constNumber, RegNumber = constRegNumber };
            string nameResult;
            string numberResult;
            string regNumberResult;

            nameResult = company.Name;
            numberResult = company.Number;
            regNumberResult = company.RegNumber;

            Assert.AreEqual(constName, nameResult);
            Assert.AreEqual(constNumber, numberResult);
            Assert.AreEqual(constRegNumber, regNumberResult);
        }

        [TestMethod]
        public void PersonPropertyIsNotModified()
        {
            string constName = "1";
            string constNumber = "2";
            Person person = new Person() { Name = constName, Number = constNumber };
            string nameResult;
            string numberResult;

            nameResult = person.Name;
            numberResult = person.Number;

            Assert.AreEqual(constName, nameResult);
            Assert.AreEqual(constNumber, numberResult);
        }
    }
}
