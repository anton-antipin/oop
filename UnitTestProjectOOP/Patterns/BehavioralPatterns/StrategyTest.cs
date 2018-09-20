using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP.Patterns.BehavioralPatterns.Strategy;

namespace UnitTestProjectOOP.Patterns.BehavioralPatterns
{
    [TestClass]
    public class StrategyTest
    {
        [TestMethod]
        public void PetrolMoveAreEqual()
        {
            string constResult = "Перемещение на бензине";
            IMovable movable = new PetrolMove();
            string result;

            result = movable.Move();

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void ElectricMoveAreEqual()
        {
            string constResult = "Перемещение на электричестве";
            IMovable movable = new ElectricMove();
            string result;

            result = movable.Move();

            Assert.AreEqual(constResult, result);
        }
    }
}
