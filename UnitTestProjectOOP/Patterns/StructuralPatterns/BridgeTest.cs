using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP.Patterns.StructuralPatterns.Bridge;

namespace UnitTestProjectOOP.Patterns.StructuralPatterns
{
    [TestClass]
    public class BridgeTest
    {
        [TestMethod]
        public void CPPLanguageAreEqual()
        {
            string constBuildResult = "С помощью компилятора C++ компилируем программу в бинарный код";
            string constExecuteResult = "Запускаем исполняемый файл программы";
            ILanguage language = new CPPLanguage();
            string buildResult;
            string executeResult;

            buildResult = language.Build();
            executeResult = language.Execute();

            Assert.AreEqual(constBuildResult, buildResult);
            Assert.AreEqual(constExecuteResult, executeResult);
        }

        [TestMethod]
        public void CSharpLanguageAreEqual()
        {
            string constBuildResult = "С помощью компилятора Roslyn компилируем исходный код в файл exe";
            string constExecuteResult = "JIT компилирует программу бинарный код" + Environment.NewLine +
                                            "CLR выполняет скомпилированный бинарный код";
            ILanguage language = new CSharpLanguage();
            string buildResult;
            string executeResult;

            buildResult = language.Build();
            executeResult = language.Execute();

            Assert.AreEqual(constBuildResult, buildResult);
            Assert.AreEqual(constExecuteResult, executeResult);
        }

        [TestMethod]
        public void FreelancerEarnMoneyAreEqual()
        {
            string constResult = "Получаем оплату за выполненный заказ";
            Programmer programmer = new Freelancer(null);
            string result;

            result = programmer.EarnMoney();

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void CorporaterEarnMoneyAreEqual()
        {
            string constResult = "Получаем в конце месяца зарплату";
            Programmer programmer = new Corporater(null);
            string result;

            result = programmer.EarnMoney();

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void FreelancerMainAreEqual()
        {
            ILanguage language = new CPPLanguage();
            Programmer programmer = new Freelancer(language);
            string constResult = string.Format("Работа:{0}{1}Оплата{2}{1}", programmer.DoWork(), Environment.NewLine, programmer.EarnMoney()); 
            string result;

            result = B_Example.Instance.Main(true, language);

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void CorporaterMainAreEqual()
        {
            ILanguage language = new CSharpLanguage();
            Programmer programmer = new Corporater(language);
            string constResult = string.Format("Работа:{0}{1}Оплата{2}{1}", programmer.DoWork(), Environment.NewLine, programmer.EarnMoney());
            string result;

            result = B_Example.Instance.Main(false, language);

            Assert.AreEqual(constResult, result);
        }
    }
}
