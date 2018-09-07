using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP.Patterns.GeneratingPatterns.Builder;

namespace UnitTestProjectOOP.Patterns.GeneratingPatterns
{
    [TestClass]
    public class BuilderTest
    {
        [TestMethod]
        public void BreadNameIsNotModified()
        {
            string constName = "хлеб";
            Bread bread = new Bread();
            string result;

            bread.Name = constName;
            result = bread.Name;

            Assert.AreEqual(constName, result);
        }

        [TestMethod]
        public void FlourSortIsNotModified()
        {
            string constSort = "мука";
            Bread bread = new Bread();
            Flour flour = new Flour();
            string result;

            flour.Sort = constSort;
            bread.Flour = flour;
            result = bread.Flour.Sort;

            Assert.AreEqual(flour, bread.Flour);
            Assert.AreEqual(constSort, result);
        }

        [TestMethod]
        public void SaltWhatIsNotModified()
        {
            string constWhat = "обычная";
            Bread bread = new Bread();
            Salt salt = new Salt();
            string result;

            salt.What = constWhat;
            bread.Salt = salt;
            result = bread.Salt.What;

            Assert.AreEqual(salt, bread.Salt);
            Assert.AreEqual(constWhat, result);
        }

        [TestMethod]
        public void AddivitiveNameIsNotModified()
        {
            string constName = "какие-то";
            Bread bread = new Bread();
            Addivitive addivitive = new Addivitive();
            string result;

            addivitive.Name = constName;
            bread.Addivitive = addivitive;
            result = bread.Addivitive.Name;

            Assert.AreEqual(addivitive, bread.Addivitive);
            Assert.AreEqual(constName, result);
        }

        [TestMethod]
        public void BredToStringAreEqual()
        {
            string name = "Пеклеваный";
            Flour flour = new Flour() { Sort = "1,2" };
            Salt salt = new Salt() { What = "морская" };
            Addivitive addivitive = new Addivitive() { Name = "супер" };

            string constResult = string.Format("Хлеб {1}:{0}Мука - {2}{0}Соль - {3}{0}Добавки - {4}{0}", Environment.NewLine,
                                                                                                name,
                                                                                                flour.Sort,
                                                                                                salt.What,
                                                                                                addivitive.Name);
            Bread bread = new Bread { Name = name, Flour = flour, Salt = salt, Addivitive = addivitive };
            string result;

            result = bread.ToString();

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void RyeBreadBakeAreEqual()
        {
            string name = "Ржаной";
            Flour flour = new Flour() { Sort = "ржаная, 1 сорт" };
            Salt salt = new Salt() { What = "обычная" };

            string constResult = string.Format("Хлеб {1}:{0}Мука - {2}{0}Соль - {3}{0}", Environment.NewLine,
                                                                                                name,
                                                                                                flour.Sort,
                                                                                                salt.What);
            BreadBuilder breadBuilder = new RyeBreadBuilder();
            string result;

            result = B_Example.Instance.Main(breadBuilder);

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void WheatBreadBakeAreEqual()
        {
            string name = "Пшеничный";
            Flour flour = new Flour() { Sort = "пшеничная, 1 сорт" };
            Salt salt = new Salt() { What = "обычная" };
            Addivitive addivitive = new Addivitive { Name = "улучшитель хлебопекарный" };

            string constResult = string.Format("Хлеб {1}:{0}Мука - {2}{0}Соль - {3}{0}Добавки - {4}{0}", Environment.NewLine,
                                                                                                name,
                                                                                                flour.Sort,
                                                                                                salt.What,
                                                                                                addivitive.Name);
            BreadBuilder breadBuilder = new WheatBreadBuilder();
            string result;

            result = B_Example.Instance.Main(breadBuilder);

            Assert.AreEqual(constResult, result);
        }

    }
}
