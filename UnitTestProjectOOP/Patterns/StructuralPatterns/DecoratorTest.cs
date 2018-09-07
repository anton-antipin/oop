using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP.Patterns.StructuralPatterns.Decorator;

namespace UnitTestProjectOOP.Patterns.StructuralPatterns
{
    [TestClass]
    public class DecoratorTest
    {
        [TestMethod]
        public void ItallianPizzaIsNotModified()
        {
            Pizza pizza = new ItallianPizza();
            string constNameResult = "Итальянская пицца";
            int constCostResult = 10;
            string nameResult;
            int costResult;

            nameResult = pizza.Name;
            costResult = pizza.GetCost();

            Assert.AreEqual(constNameResult, nameResult);
            Assert.AreEqual(constCostResult, costResult);
        }

        [TestMethod]
        public void BulgerianPizzaIsNotModified()
        {
            Pizza pizza = new BulgerianPizza();
            string constNameResult = "Болгарская пицца";
            int constCostResult = 8;
            string nameResult;
            int costResult;

            nameResult = pizza.Name;
            costResult = pizza.GetCost();

            Assert.AreEqual(constNameResult, nameResult);
            Assert.AreEqual(constCostResult, costResult);
        }

        [TestMethod]
        public void TomatoPizzaIsNotModified()
        {
            Pizza pizza = new ItallianPizza();
            PizzaDecorator pizzaDecorator = new TomatoPizza(pizza);

            string constNameResult = pizza.Name + ", с томатами";
            int constCostResult = 10 + 3;
            string nameResult;
            int costResult;

            nameResult = pizzaDecorator.Name;
            costResult = pizzaDecorator.GetCost();

            Assert.AreEqual(constNameResult, nameResult);
            Assert.AreEqual(constCostResult, costResult);
        }

        [TestMethod]
        public void CheesePizzaIsNotModified()
        {
            Pizza pizza = new BulgerianPizza();
            PizzaDecorator pizzaDecorator = new CheesePizza(pizza);

            string constNameResult = pizza.Name + ", с сыром";
            int constCostResult = 8 + 5;
            string nameResult;
            int costResult;

            nameResult = pizzaDecorator.Name;
            costResult = pizzaDecorator.GetCost();

            Assert.AreEqual(constNameResult, nameResult);
            Assert.AreEqual(constCostResult, costResult);
        }
    }
}
