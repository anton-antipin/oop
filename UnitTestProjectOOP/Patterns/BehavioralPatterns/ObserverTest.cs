using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP.Patterns.BehavioralPatterns.Observer;

namespace UnitTestProjectOOP.Patterns.BehavioralPatterns
{
    [TestClass]
    public class ObserverTest
    {
        [TestMethod]
        public void StockInfoIsNotModified()
        {
            int constUSD = 55;
            int constEU = 66;
            StockInfo stockInfo = new StockInfo() { USD = constUSD, EU = constEU };
            int resultUSD;
            int resultEU;

            resultUSD = stockInfo.USD;
            resultEU = stockInfo.EU;            

            Assert.AreEqual(constUSD, resultUSD);
            Assert.AreEqual(constEU, resultEU);
        }

        [TestMethod]
        public void BrokerAndBankSaleAreEqual()
        {
            int constUSD = 100;
            int constEU = 100;
            string constResult = "Банк ЮС продает евро" + Environment.NewLine + "Брокер Б продает доллары" + Environment.NewLine;
            Stock stock = new Stock();
            string result;

            result = O_Example.Instance.Main(stock, constUSD, constEU);

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void BrokerAndBankNotSaleAreEqual()
        {
            int constUSD = 10;
            int constEU = 10;
            string constResult = "Банк ЮС покупает евро" + Environment.NewLine + "Брокер Б покупает доллары" + Environment.NewLine;
            Stock stock = new Stock();
            string result;

            result = O_Example.Instance.Main(stock, constUSD, constEU);

            Assert.AreEqual(constResult, result);
        }
    }
}
