using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP.Patterns.BehavioralPatterns.State;

namespace UnitTestProjectOOP.Patterns.BehavioralPatterns
{
    [TestClass]
    public class StateTest
    {
        [TestMethod]
        public void WaterWSIsNotModified()
        {
            IWaterState waterState = new SolidWS();
            Water water = new Water(waterState);
            IWaterState result;

            result = water.WaterState;

            Assert.AreEqual(waterState, result);
        }

        [TestMethod]
        public void SolidWSHeatAreEqual()
        {
            string constResult = "Превращаем лёд в жидкость";
            IWaterState waterState = new SolidWS();
            Water water = new Water(waterState);
            string result;

            result = waterState.Heat(water);

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void SolidWSFrostAreEqual()
        {
            string constResult = "Продолжаем заморозку льда";
            IWaterState waterState = new SolidWS();
            Water water = new Water(waterState);
            string result;

            result = waterState.Frost(water);

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void LiquidWSHeatAreEqual()
        {
            string constResult = "Превращаем жидкость в пар";
            IWaterState waterState = new LiquidWS();
            Water water = new Water(waterState);
            string result;

            result = waterState.Heat(water);

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void LiquidWSFrostAreEqual()
        {
            string constResult = "Превращаем жидкость в лёд";
            IWaterState waterState = new LiquidWS();
            Water water = new Water(waterState);
            string result;

            result = waterState.Frost(water);

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void GassWSHeatAreEqual()
        {
            string constResult = "Повышаем температуру водяного пара";
            IWaterState waterState = new GassWS();
            Water water = new Water(waterState);
            string result;

            result = waterState.Heat(water);

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void GassWSFrostAreEqual()
        {
            string constResult = "Превращаем водяной пар в жидкость";
            IWaterState waterState = new GassWS();
            Water water = new Water(waterState);
            string result;

            result = waterState.Frost(water);

            Assert.AreEqual(constResult, result);
        }
    }
}
