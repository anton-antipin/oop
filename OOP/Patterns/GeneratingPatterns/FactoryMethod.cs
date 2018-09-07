// 1. определяет интерфейс для создания объектов некоторого класса, но непосредственное решение о том, 
//      объект какого класса создавать, происходит в подклассах (предполагает что базовый класс делегирует
//      создание объектов классам-наследникам)
// 2.   - когда заранее не известно объекты каких типов необходимо создавать
//      - когда система должна быть независимой от процесса создания новых объектов и расширяемой
//          (в нее можно легко вводить новые классы, объекты которых система должна создавать)
//      - когда создание новых объектов необходимо делегировать из базового класса классам-наследникам
// 3. для каждого нового класса необходимо создавать свой класс создателя

using System;

namespace OOP.Patterns.GeneratingPatterns.FactoryMethod
{
    #region Template
    // класс-интерфейс и его реализация для объектов, которые необходимо создавать
    abstract class Product { }
    class ConcreteProductA : Product { }
    class ConcreteProductB : Product { }

    // класс-интерфейс с фабричным методом и его реализация в классах-наследниках, 
    // определяющие свою реализацию создания продукта
    abstract class Creator
    {
        public abstract Product FactoryMethod();
    }
    class ConcreteCreatorA : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductA();
        }
    }
    class ConcreteCreatorB : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductB();
        }
    }
    #endregion

    #region DevelopmentExample
    public abstract class House
    {
        public string State { get; set; }
    }
    public class PanelHouse : House
    {
        public PanelHouse()
        {
            State = "Панельный дом построен";
        }
    }
    public class WoodHouse : House
    {
        public WoodHouse()
        {
            State = "Деревянный дом построен";
        }
    }

    public abstract class Developer
    {
        public string Name { get; set; }
        public Developer(string name)
        {
            Name = name;
        }
        abstract public House Create();
    }
    public class PanelDeveloper : Developer
    {
        public PanelDeveloper(string name) : base(name)
        {

        }

        public override House Create()
        {
            return new PanelHouse();
        }
    }
    public class WoodDeveloper : Developer
    {
        public WoodDeveloper(string name) : base(name)
        {

        }

        public override House Create()
        {
            return new WoodHouse();
        }
    }

    public class FM_Example
    {
        private static FM_Example _instance;
        private static readonly object _synchrObj = new object();

        private FM_Example()
        {

        }

        public static FM_Example Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock(_synchrObj)
                    {
                        if (_instance == null)
                            _instance = new FM_Example();
                    }
                }
                return _instance;
            }
        }

        public string Main(Developer developer)
        {
            House house = developer.Create();

            return string.Format("Строитель - {0}; Состояние дома - {1}.", developer.Name, house.State);
        }
    }
    #endregion
}
