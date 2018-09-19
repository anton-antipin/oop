// 1. позволяет использовать разделяемые объекты сразу в нескольких контекстах
//      используется преимущественно для оптимизации работы с памятью
//      ключевым моментом является разделение состояний на внутреннее и внешнее
//      внутреннее состояние не зависит от контекста - оно может быть разделяемым и поэтому выносится в разделяемые объекты
//      внешнее состояние зависит от контекста, является изменчивым
// 2.   - когда приложение использует большое количество однообразных объектов
//      из-за чего происходит выделение большого количества памяти
//      - когда часть состояния объекта которое является изменяемым можно вывести во вне
// 3. 

using System.Collections;
using System.Collections.Generic;

namespace OOP.Patterns.StructuralPatterns.Flyweight
{
    #region Template
    abstract class Flyweight
    {
        public abstract void Operation(int extrinsicState);
    }
    class ConcreteFlyweight : Flyweight
    {
        private int intrinsicState;

        public override void Operation(int extrinsicState)
        {
            intrinsicState = extrinsicState;
        }
    }
    class UnsharedFlyweight : Flyweight
    {
        int allState;

        public override void Operation(int extrinsicState)
        {
            allState = extrinsicState;
        }
    }

    class FlyweightFactory
    {
        private Hashtable flyweight = new Hashtable();

        public FlyweightFactory()
        {
            flyweight.Add("X", new ConcreteFlyweight());
            flyweight.Add("Y", new ConcreteFlyweight());
            flyweight.Add("Z", new ConcreteFlyweight());
        }

        public Flyweight GetFlyweight(string key)
        {
            if (!flyweight.ContainsKey(key))
                flyweight.Add(key, new ConcreteFlyweight());
            return flyweight[key] as Flyweight;
        }
    }
    #endregion

    #region BuildingHouse
    public abstract class House
    {
        protected int _stages;

        public abstract string Build(double longitude, double latitude);
    }
    public class PanelHouse : House
    {
        public PanelHouse()
        {
            _stages = 16;
        }

        public override string Build(double longitude, double latitude)
        {
            return string.Format("Построен панельный дом {0} этажей; координаты - {1} широты, {2} долготы.", _stages, longitude, latitude);
        }
    }
    public class BrickHouse : House
    {
        public BrickHouse()
        {
            _stages = 5;
        }

        public override string Build(double longitude, double latitude)
        {
            return string.Format("Построен кирпичный дом {0} этажей; координаты - {1} широты, {2} долготы.", _stages, longitude, latitude);
        }
    }

    public class HouseFactory
    {
        private readonly Dictionary<string, House> _dictionary = new Dictionary<string, House>();

        public HouseFactory()
        {
            _dictionary.Add("panel", new PanelHouse());
            _dictionary.Add("brik", new BrickHouse());
        }

        public House GetHouse(string key)
        {
            if (_dictionary.ContainsKey(key))
                return _dictionary[key];
            else
                return null;
        }
    }

    public class F_Example
    {
        private static F_Example _instance;
        private static readonly object _syncObj = new object();

        private F_Example()
        {

        }

        public static F_Example Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock(_syncObj)
                    {
                        if (_instance == null)
                            _instance = new F_Example();
                    }
                }
                return _instance;
            }
        }

        public string Main(string key, double longitude, double latitude)
        {
            HouseFactory houseFactory = new HouseFactory();
            House house = houseFactory.GetHouse(key);
            string result = string.Empty;

            if (house != null)
                result = house.Build(longitude, latitude);

            return result;
        }
    }
    #endregion
}
