using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP.Patterns.BehavioralPatterns.Memento;

namespace UnitTestProjectOOP.Patterns.BehavioralPatterns
{
    [TestClass]
    public class MementoTest
    {
        [TestMethod]
        public void HeroShootAreEqual()
        {
            int constPatron = 9;
            string constResult = string.Format("Производим выстрел, осталось {0} патронов", constPatron);
            Hero hero = new Hero();
            string result;

            result = hero.Shoot();

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void HeroMomentoAreEqual()
        {
            int constShoot = 4;
            int constRestore = 3;
            int constPatron = 7;
            string constResult = string.Format("Производим выстрел, осталось {0} патронов", constPatron);
            
            string result;

            result = M_Example.Instance.Main(constShoot, constRestore);

            Assert.AreEqual(constResult, result);
        }
    }
}
