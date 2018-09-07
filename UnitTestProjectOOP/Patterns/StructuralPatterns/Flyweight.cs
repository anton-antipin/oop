using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP.Patterns.StructuralPatterns.Flyweight;

namespace UnitTestProjectOOP.Patterns.StructuralPatterns
{
    [TestClass]
    public class Flyweight
    {
        [TestMethod]
        public void PanelHouseBuildAreEqual()
        {
            int stages = 16;
            double longitude = 0.1;
            double latitude = 0.1;
            string constResult = string.Format("Построен панельный дом {0} этажей; координаты - {1} широты, {2} долготы.", stages, longitude, latitude);
            House house = new PanelHouse();
            string result;

            result = house.Build(longitude, latitude);

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void BrikHouseBuildAreEqual()
        {
            int stages = 5;
            double longitude = 0.1;
            double latitude = 0.1;
            string constResult = string.Format("Построен кирпичный дом {0} этажей; координаты - {1} широты, {2} долготы.", stages, longitude, latitude);
            House house = new BrickHouse();
            string result;

            result = house.Build(longitude, latitude);

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void HouseFactoryBuildPanelAreEqual()
        {
            int stages = 16;
            double longitude = 0.1;
            double latitude = 0.1;
            string constResult = string.Format("Построен панельный дом {0} этажей; координаты - {1} широты, {2} долготы.", stages, longitude, latitude);
            string house = "panel";
            string result;

            result = F_Example.Instance.Main(house, longitude, latitude);

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void HouseFactoryBuildBrikAreEqual()
        {
            int stages = 5;
            double longitude = 0.1;
            double latitude = 0.1;
            string constResult = string.Format("Построен кирпичный дом {0} этажей; координаты - {1} широты, {2} долготы.", stages, longitude, latitude);
            string house = "brik";
            string result;

            result = F_Example.Instance.Main(house, longitude, latitude);

            Assert.AreEqual(constResult, result);
        }
    }
}
