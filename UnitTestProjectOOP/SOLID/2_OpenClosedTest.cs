using System;
using OOP.SOLID._2_OpenClosed;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProjectOOP.SOLID
{
    [TestClass]
    public class OpenClosedTest
    {
        [TestMethod]
        public void ConstructNamePropertyIsNotModified()
        {
            string text = "Dave";
            string result;

            Cook cook = new Cook(text);
            result = cook.Name;

            Assert.AreEqual(text, result);
        }

        [TestMethod]
        public void NameAsPropertyIsNotModified()
        {
            string text = "Dave";
            string result;
            Cook cook = new Cook(String.Empty);

            cook.Name = text;
            result = cook.Name;

            Assert.AreEqual(text, result);
        }

        [TestMethod]
        public void MakePotatoMealAreEqual()
        {
            string text = "";
            text = String.Format("{0} Чистим картошку {1}", text, Environment.NewLine);
            text = String.Format("{0} Ставим почищенную картошку на огонь {1}", text, Environment.NewLine);
            text = String.Format("{0} Сливаем остатки воды, разминаем варенный картофель в пюре {1}", text, Environment.NewLine);
            text = String.Format("{0} Посыпаем пюре специями и зеленью {1}", text, Environment.NewLine);
            text = String.Format("{0} Картофельное пюре готово {1}", text, Environment.NewLine);
            string result; 
            IMeal potatoMeal = new PotatoMeal();

            result = potatoMeal.Make();

            Assert.AreEqual(text, result);
        }

        [TestMethod]
        public void MakeCookWithPotatoMealAreEqual()
        {
            string text = "";
            text = String.Format("{0} Чистим картошку {1}", text, Environment.NewLine);
            text = String.Format("{0} Ставим почищенную картошку на огонь {1}", text, Environment.NewLine);
            text = String.Format("{0} Сливаем остатки воды, разминаем варенный картофель в пюре {1}", text, Environment.NewLine);
            text = String.Format("{0} Посыпаем пюре специями и зеленью {1}", text, Environment.NewLine);
            text = String.Format("{0} Картофельное пюре готово {1}", text, Environment.NewLine);
            string result;

            result = Example00.Instance.Main();

            Assert.AreEqual(text, result);
        }
    }
}
