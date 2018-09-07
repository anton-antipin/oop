// 1. позволяет динамически подключать к объекту дополнительную функциональность
// 2.   - когда надо динамически добавлять к объекту новые функциональные возможности
//      - когда применение наследования неприемлимо 
// 3.

using System;

namespace OOP.Patterns.StructuralPatterns.Decorator
{
    #region Template
    // определяет интерфейс и реализацию в которую 
    // с помощью декоратора добавляется новая функциональность
    // интерфейс должен быть легким
    abstract class Component
    {
        public abstract void Operation();
    }
    class ConcreteComponent : Component
    {
        public override void Operation()
        {
            
        }
    }

    // имеет тот же базовый класс что и декорируемые объекты 
    abstract class Decorator : Component
    {
        private Component _component;

        public void SetComponent(Component component)
        {
            _component = component;
        }

        public override void Operation()
        {
            if (_component != null)
                _component.Operation();
        }
    }
    class ConcreteDecoratorA : Decorator
    {
        public override void Operation()
        {
            base.Operation();
        }
    }
    class ConcreteDecoratorB : Decorator
    {
        public override void Operation()
        {
            base.Operation();
        }
    }
    #endregion

    #region Pizzeria
    public abstract class Pizza
    {
        public Pizza(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public abstract int GetCost();
    }
    public class ItallianPizza : Pizza
    {
        public ItallianPizza() : base("Итальянская пицца")
        { 
        }

        public override int GetCost()
        {
            return 10;
        }
    }
    public class BulgerianPizza : Pizza
    {
        public BulgerianPizza() : base("Болгарская пицца")
        {

        }

        public override int GetCost()
        {
            return 8;

        }
    }

    public abstract class PizzaDecorator : Pizza
    {
        protected Pizza _pizza;
        public PizzaDecorator(string name, Pizza pizza) : base(name)
        {
            _pizza = pizza;
        }
    }
    public class TomatoPizza : PizzaDecorator
    {
        public TomatoPizza(Pizza pizza) : base(pizza.Name + ", с томатами", pizza)
        {

        }

        public override int GetCost()
        {
            return _pizza.GetCost() + 3;
        }
    }
    public class CheesePizza : PizzaDecorator
    {
        public CheesePizza(Pizza pizza): base(pizza.Name + ", с сыром", pizza)
        {

        }

        public override int GetCost()
        {
            return _pizza.GetCost() + 5;
        }
    }

    public class D_Example
    {
        private static D_Example _instance;
        private static readonly object _syncObj = new object();

        private D_Example()
        {

        }

        public static D_Example Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock(_syncObj)
                    {
                        if (_instance == null)
                            _instance = new D_Example();
                    }
                }
                return _instance;
            }
        }

        public string Main(Pizza pizza)
        {
            return string.Format("Была приготовлена: {0}{1}Стоймость:{2}", pizza.Name, Environment.NewLine, pizza.GetCost());
        }
    }
    #endregion
}
