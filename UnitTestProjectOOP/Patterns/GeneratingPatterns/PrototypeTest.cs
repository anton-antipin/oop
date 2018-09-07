using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP.Patterns.GeneratingPatterns.Prototype;

namespace UnitTestProjectOOP.Patterns.GeneratingPatterns
{
    [TestClass]
    public class PrototypeTest
    {
        [TestMethod]
        public void RectangleCloneTypeIsNotModified()
        {
            IFigure figure = new Rectangle(10, 10);
            IFigure result;

            result = figure.Clone();

            Assert.IsTrue(result is Rectangle);
        }

        [TestMethod]
        public void CircleCloneTypeIsNotModified()
        {
            IFigure figure = new Circle(10);
            IFigure result;

            result = figure.Clone();

            Assert.IsTrue(result is Circle);
        }

        [TestMethod]
        public void RectangleGetInfoAreEqual()
        {
            int width = 10;
            int height = 10;
            string constResult = string.Format("Прямоугольник длиной {0} и шириной {0}.", height, width);

            IFigure figure = new Rectangle(width, height);
            string result;

            result = figure.GetInfo();

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void CircleGetInfoAreEqual()
        {
            int radius = 10;
            string constResult = string.Format("Круг радиусом {0}", radius);

            IFigure figure = new Circle(radius);
            string result;

            result = figure.GetInfo();

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void RectangleCloneIsNotModified()
        {
            IFigure figure = new Rectangle(10, 10);
            string constString = figure.GetInfo();
            string result;

            result = P_Example.Instance.Main(figure);

            Assert.AreEqual(constString, result);
        }

        [TestMethod]
        public void CircleCloneIsNotModified()
        {
            IFigure figure = new Circle(10);
            string constString = figure.GetInfo();
            string result;

            result = P_Example.Instance.Main(figure);

            Assert.AreEqual(constString, result);
        }
    }
}
