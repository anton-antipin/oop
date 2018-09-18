using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP.Patterns.BehavioralPatterns.Command;

namespace UnitTestProjectOOP.Patterns.BehavioralPatterns
{
    [TestClass]
    public class CommandTest
    {
        [TestMethod]
        public void TVOnAreEqual()
        {
            string constResult = "Телевизор включен";
            TV tv = new TV();
            string result;

            result = tv.On();

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void TVOffAreEqual()
        {
            string constResult = "Телевизор выключен";
            TV tv = new TV();
            string result;

            result = tv.Off();

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void TVOnCommandExecuteAreEqual()
        {
            string constResult = "Телевизор включен";
            TV tv = new TV();
            ICommand command = new TVOnCommand(tv);
            string result;

            result = command.Execute();

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void TVOnCommandUndoAreEqual()
        {
            string constResult = "Телевизор выключен";
            TV tv = new TV();
            ICommand command = new TVOnCommand(tv);
            string result;

            result = command.Undo();

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void PultPressButtonAreEqual()
        {
            string constResult = "Телевизор включен";
            ICommand command = new TVOnCommand(null);
            string result;

            result = C_Example.Instance.Main(command, true);

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void PultPressUndoAreEqual()
        {
            string constResult = "Телевизор выключен";
            ICommand command = new TVOnCommand(null);
            string result;

            result = C_Example.Instance.Main(command, false);

            Assert.AreEqual(constResult, result);
        }

    }
}
