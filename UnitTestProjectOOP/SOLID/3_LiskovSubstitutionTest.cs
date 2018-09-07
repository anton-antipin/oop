using System;
using OOP.SOLID._3_LiskovSubstitution;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProjectOOP.SOLID
{
    [TestClass]
    public class LiskovSubstitutionTest
    {
        [TestMethod]
        public void WidthRectangleIsNotModified()
        {
            int width = 5;
            Rectangle rec = new Rectangle();

            rec.Width = width;

            Assert.AreEqual(width, rec.Width);
        }

        [TestMethod]
        public void HeightRectangleIsNotModified()
        {
            int height = 5;
            Rectangle rec = new Rectangle();

            rec.Height = height;

            Assert.AreEqual(height, rec.Height);
        }

        [TestMethod]
        public void WidthAndHeightSquareIsNotModified()
        {
            int width = 5;
            Square rec = new Square();

            rec.Width = width;

            Assert.AreEqual(width, rec.Width);
            Assert.AreEqual(width, rec.Height);
        }

        [TestMethod]
        public void HeightAndWidthSquareIsNotModified()
        {
            int height = 5;
            Square rec = new Square();

            rec.Height = height;

            Assert.AreEqual(height, rec.Height);
            Assert.AreEqual(height, rec.Width);
        }

        [TestMethod]
        public void GetAreaRectangleAreEqual()
        {
            int width = 3;
            int height = 5;
            int constArea = width * height;
            int result = 0;
            Rectangle rec = new Rectangle();

            rec.Width = width;
            rec.Height = height;

            result = Example00.Instance.Main(rec);

            Assert.AreEqual(constArea, result);
        }

        [TestMethod]
        public void GetAreaSquareAreNotEqual()
        {
            int width = 3;
            int height = 5;
            int constArea = width * height;
            int result = 0;
            Square sqr = new Square();

            sqr.Width = width;
            sqr.Height = height;

            result = Example00.Instance.Main(sqr);

            Assert.AreNotEqual(constArea, result);
        }
    }
}
