using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP.Patterns.GeneratingPatterns.FactoryMethod;

namespace UnitTestProjectOOP.Patterns.GeneratingPatterns
{
    [TestClass]
    public class FactoryMethodTest
    {
        [TestMethod]
        public void PanelHouseIsNotModified()
        {
            string constState = "Панельный дом построен";
            House house = new PanelHouse();
            string result;

            result = house.State;

            Assert.AreEqual(constState, result);
        }

        [TestMethod]
        public void WoodHouseIsNotModified()
        {
            string constState = "Деревянный дом построен";
            House house = new WoodHouse();
            string result;

            result = house.State;

            Assert.AreEqual(constState, result);
        }

        [TestMethod]
        public void PanelDeveloperIsTrue()
        {
            Developer developer = new PanelDeveloper("строитель");
            House result;

            result = developer.Create();

            Assert.IsTrue(result is PanelHouse);
        }

        [TestMethod]
        public void WoodDeveloperIsTrue()
        {
            Developer developer = new WoodDeveloper("строитель");
            House result;

            result = developer.Create();

            Assert.IsTrue(result is WoodHouse);
        }

        [TestMethod]
        public void PanelDeveloperAreEqual()
        {
            string name = "панельный строитель";
            string constResult = string.Format("Строитель - {0}; Состояние дома - Панельный дом построен.", name);

            Developer developer = new PanelDeveloper(name);
            string result;

            result = FM_Example.Instance.Main(developer);

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void WoodDeveloperAreEqual()
        {
            string name = "деревянный строитель";
            string constResult = string.Format("Строитель - {0}; Состояние дома - Деревянный дом построен.", name);

            Developer developer = new WoodDeveloper(name);
            string result;

            result = FM_Example.Instance.Main(developer);

            Assert.AreEqual(constResult, result);
        }
    }
}
